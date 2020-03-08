using System;
using TP_Groupe.Models;
using System.Collections.Generic;
using System.Linq;

namespace TP_Groupe.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly AppDbContext _dbContext;
        // private readonly AppDbContext _dbSet;

        public ArticleRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public void Insert(Article article)
        {
            _dbContext.Articles.Add(article);
            _dbContext.SaveChanges();
        }
        public void Update(Article article)
        {
            _dbContext.Update(article);
            _dbContext.SaveChanges();

        }
        public void Remove(Article article)
        {
            _dbContext.Remove(article);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Article> GetAllArticles()
        {
            return  _dbContext.Articles;
        }

        public Article GetById(int id)
        {
            return _dbContext.Articles.FirstOrDefault(a => a.Id == id);
        }
    }
}
