using System;
using System.Collections.Generic;

namespace TP_Groupe.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string SKU { get; set; }
        public DateTime DateSortie { get; set; }
        public float PrixInitial { get; set; }
        public float Poids { get; set; }
        public virtual ICollection<PositionMagasin> ArticleEtageres { get; set; }
   
        
    }
}