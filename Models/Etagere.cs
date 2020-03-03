using System;
using System.Collections.Generic;

namespace TP_Groupe.Models
{
    public class Etagere
    {
        public int Id { get; set; }
        public Decimal PoidsMaximum { get; set; }
        public virtual ICollection<PositionMagasin> ArticleEtageres { get; set; }
        public int SecteurId { get; set; }
        public Secteur Secteur { get; set; }
    }
}
