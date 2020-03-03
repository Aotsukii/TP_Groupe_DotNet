using System;
using System.Collections.Generic;
using TP_Groupe.Models;

namespace TP_Groupe.Repository
{
    public interface IArticleRepository
    {
        void Insert(Article article);
        void Update(Article article);
        void Remove(Article article);
        Article GetById(int Id);
    }
}
