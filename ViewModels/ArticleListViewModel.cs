using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP_Groupe.Models;

namespace TP_Groupe.ViewModels
{
    public class ArticleListViewModel
    {
        public IEnumerable<Article> Articles {get;set;}
    }
}