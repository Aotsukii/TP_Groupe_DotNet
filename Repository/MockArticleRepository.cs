using System;
using System.Collections.Generic;
using System.Linq;
using TP_Groupe.Models;

namespace TP_Groupe.Repository
{
    public class MockArticleRepository : IArticleRepository
    {
        public void Insert(Article article)
        {
            throw new NotFiniteNumberException();
        }
        public void Update(Article article)
        {
            throw new NotFiniteNumberException();
        }
        public void Remove(Article article)
        {
            throw new NotFiniteNumberException();
        }
        public List<Article> GetAllArticles()
        {
            return new List<Article>()
            {
                new Article
                {
                    Id = 1,
                    Libelle = "PC ASUS",
                    SKU = "PC01",
                    DateSortie = DateTime.Now,
                    PrixInitial = 590.90F,
                    Poids = 2.8F
                },
                new Article
                {
                    Id = 2,
                    Libelle = "PC LENOVO",
                    SKU = "PC02",
                    DateSortie = DateTime.Now,
                    PrixInitial = 590.90F,
                    Poids = 2.8F
                },
                new Article
                {
                    Id = 3,
                    Libelle = "PC HP",
                    SKU = "PC03",
                    DateSortie = DateTime.Now,
                    PrixInitial = 590.90F,
                    Poids = 2.8F
                },
                new Article
                {
                    Id = 4,
                    Libelle = "PC DELL",
                    SKU = "PC04",
                    DateSortie = DateTime.Now,
                    PrixInitial = 590.90F,
                    Poids = 2.8F
                }
            };
        }
        public Article GetById(int id)
        {
            return GetAllArticles().FirstOrDefault(a => a.Id == id);
        }
    }
}