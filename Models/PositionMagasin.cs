using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TP_Groupe.Models
{
    public class PositionMagasin
    {
        
        public int IdArticle { get; set; }
        public Article Article { get; set; }
        public int IdEtagere { get; set; }
        public Etagere Etagere { get; set; }
        public int Quantite { get; set; }
    }
}
