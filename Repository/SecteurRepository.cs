using System;
using TP_Groupe.Models;
using System.Collections.Generic;
using System.Linq;

namespace TP_Groupe.Repository
{
    public class SecteurRepository : ISecteurRepository
    {
        private readonly AppDbContext _dbContext;
        // private readonly AppDbContext _dbSet;

        public SecteurRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.SaveChanges();
        }
        
        public void Insert(Secteur secteur)
        {
            _dbContext.Secteurs.Add(secteur);
            _dbContext.SaveChanges();
        }
        public void Update(Secteur secteur)
        {
            _dbContext.Update(secteur);
            _dbContext.SaveChanges();
        }
        public void Remove(Secteur secteur)
        {
            _dbContext.Remove(secteur);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Secteur> GetAllSecteurs()
        {
            return  _dbContext.Secteurs;
        }

        public Secteur GetById(int id)
        {
            return _dbContext.Secteurs.FirstOrDefault(a => a.Id == id);
        }
    }
}
