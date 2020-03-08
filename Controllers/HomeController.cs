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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleRepository _articleRepository;

        public HomeController(IArticleRepository articleRepository, ILogger<HomeController> logger)
        {
            _logger = logger;
            _articleRepository = articleRepository;
        }

        public IActionResult Index()
        {
            var listArticle = new ArticleListViewModel();
            listArticle.Articles = _articleRepository.GetAllArticles().Take(4);
            return View(listArticle);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
