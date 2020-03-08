using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TP_Groupe.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string SKU { get; set; }
        public DateTime DateSortie { get; set; }
        public float PrixInitial { get; set; }
        public float Poids { get; set; }
        public virtual ICollection<PositionMagasin> ArticleEtageres { get; set; }
   
        
    }
}