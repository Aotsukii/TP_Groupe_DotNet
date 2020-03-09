using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TP_Groupe.Models;
using TP_Groupe.Repository;
using TP_Groupe.ViewModels;


namespace TP_Groupe.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IEtagereRepository _etagereRepository;
        private readonly IPositionMagasinRepository _positionMagasinRepository;
        private readonly ISecteurRepository _secteurRepository;

        private readonly AppDbContext _context;

        public ArticleController( AppDbContext context, IArticleRepository articleRepository, IEtagereRepository etagereRepository, IPositionMagasinRepository positionMagasinRepository, ISecteurRepository secteurRepository)
        {
            _articleRepository = articleRepository;
            _etagereRepository = etagereRepository;
            _positionMagasinRepository = positionMagasinRepository;
            _secteurRepository = secteurRepository;
            _context = context;
        }

        public IActionResult List()
        {
            // if (_file.Exists("tp_mspr.db"))
            // {
            //     _file.Delete("tp_mspr.db");
            // }
            _context.Database.EnsureCreated();

            _context.Articles.Add(new Article
            {
                Libelle = "PC ASUS",
                SKU = "PC01",
                DateSortie = DateTime.Now,
                PrixInitial = 590.90F,
                Poids = 2.8F
            });

            _context.Articles.Add(new Article
            {
                Libelle = "PC LENOVO",
                SKU = "PC02",
                DateSortie = DateTime.Now,
                PrixInitial = 699.90F,
                Poids = 3.8F
            });

            _context.SaveChanges();

            var articleListViewModel = new ArticleListViewModel();
            articleListViewModel.Articles = _articleRepository.GetAllArticles();
            return View(articleListViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Article article)
        {
            _articleRepository.Insert(article);
            return View();
        }

        public IActionResult Edit(int idArticle)
        {
            var article = _articleRepository.GetById(idArticle);
            if(article == null){
                return NotFound();
            } else {
                return View(article);
            }
        }

        [HttpPost]
        public IActionResult Edit(Article article)
        {
            _articleRepository.Update(article);
            return View(article);
        }

        public IActionResult Delete(int idArticle)
        {
            var article = _articleRepository.GetById(idArticle);
            ViewData["message"] = "L'article '" + article.Libelle + "' a été supprimé avec succès !";
            if(article == null){
                return NotFound();
            } else {
                _articleRepository.Remove(article);
                return View(article);
            }
        }
    }
}
