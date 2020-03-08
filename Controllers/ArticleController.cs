using System;
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

        public ArticleController(IArticleRepository articleRepository, IEtagereRepository etagereRepository, IPositionMagasinRepository positionMagasinRepository, ISecteurRepository secteurRepository)
        {
            _articleRepository = articleRepository;
            _etagereRepository = etagereRepository;
            _positionMagasinRepository = positionMagasinRepository;
            _secteurRepository = secteurRepository;
        }

        public IActionResult List()
        {
            var articleListViewModel = new ArticleListViewModel();
            articleListViewModel.Articles = _articleRepository.GetAllArticles();
            return View(articleListViewModel);
        }
    }
}
