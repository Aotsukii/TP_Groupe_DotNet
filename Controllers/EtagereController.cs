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
    public class EtagereController : Controller
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IEtagereRepository _etagereRepository;
        private readonly IPositionMagasinRepository _positionMagasinRepository;
        private readonly ISecteurRepository _secteurRepository;

        private readonly AppDbContext _context;

        public EtagereController( AppDbContext context, IArticleRepository articleRepository, IEtagereRepository etagereRepository, IPositionMagasinRepository positionMagasinRepository, ISecteurRepository secteurRepository)
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

            var secteur = new Secteur();
            secteur.Nom = "Informatique";
            
            _context.Secteurs.Add(secteur);

            _context.Etageres.Add(new Etagere
            {
                PoidsMaximum = 100F,
                Secteur = secteur,
                SecteurId = secteur.Id
            });

            _context.Etageres.Add(new Etagere
            {
                PoidsMaximum = 100F,
                Secteur = secteur,
                SecteurId = secteur.Id
            });

            _context.SaveChanges();

            var etagereListViewModel = new EtagereListViewModel();
            etagereListViewModel.Etageres = _etagereRepository.GetAllEtageres();
            return View(etagereListViewModel);
        }

        public IActionResult Edit(int idEtagere)
        {
            var etagere = _etagereRepository.GetById(idEtagere);
            if(etagere == null){
                return NotFound();
            } else {
                return View(etagere);
            }
        }
    }
}
