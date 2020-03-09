using System;
using TP_Groupe.Models;
using System.Collections.Generic;
using System.Linq;

namespace TP_Groupe.Repository
{
    public class EtagereRepository : IEtagereRepository
    {
        private readonly AppDbContext _dbContext;
        // private readonly AppDbContext _dbSet;

        public EtagereRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public void Insert(Etagere etagere)
        {
            _dbContext.Etageres.Add(etagere);
            _dbContext.SaveChanges();
        }
        public void Update(Etagere etagere)
        {
            _dbContext.Update(etagere);
            _dbContext.SaveChanges();

        }
        public void Remove(Etagere etagere)
        {
            _dbContext.Remove(etagere);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Etagere> GetAllEtageres()
        {
            return  _dbContext.Etageres;
        }

        public Etagere GetById(int id)
        {
            return _dbContext.Etageres.FirstOrDefault(e => e.Id == id);
        }
    }
}
