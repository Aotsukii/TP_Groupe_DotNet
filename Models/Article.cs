using System;
using System.Collections.Generic;

namespace TP_Groupe.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string SKE { get; set; }
        public DateTime DateSortie { get; set; }
        public int PrixInitial { get; set; }
        public Decimal Poids { get; set; }
        public virtual ICollection<PositionMagasin> ArticleEtageres { get; set; }
   
        
    }
}