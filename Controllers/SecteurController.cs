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
    public class SecteurController : Controller
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IEtagereRepository _etagereRepository;
        private readonly IPositionMagasinRepository _positionMagasinRepository;
        private readonly ISecteurRepository _secteurRepository;

        private readonly AppDbContext _context;

        public SecteurController( AppDbContext context, IArticleRepository articleRepository, IEtagereRepository etagereRepository, IPositionMagasinRepository positionMagasinRepository, ISecteurRepository secteurRepository)
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

            _context.Secteurs.Add(new Secteur
            {
                Nom = "Multimédia"
            });

            _context.Secteurs.Add(new Secteur
            {
                Nom = "Bureautique"
            });

            _context.Secteurs.Add(new Secteur
            {
                Nom = "Jeux vidéos"
            });

            _context.Secteurs.Add(new Secteur
            {
                Nom = "Divers"
            });

            _context.SaveChanges();

            var secteurListViewModel = new SecteurListViewModel();
            secteurListViewModel.Secteurs = _secteurRepository.GetAllSecteurs();
            return View(secteurListViewModel);
        }

        public IActionResult Edit(int idSecteur)
        {
            var secteur = _secteurRepository.GetById(idSecteur);
            if(secteur == null){
                return NotFound();
            } else {
                return View(secteur);
            }
        }
    }
}
