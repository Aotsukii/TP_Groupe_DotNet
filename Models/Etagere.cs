using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Groupe.Models
{
    public class Etagere
    {
        [Key]
        public int Id { get; set; }
        public float PoidsMaximum { get; set; }
        public virtual ICollection<PositionMagasin> ArticleEtageres { get; set; }
        [ForeignKey("Secteur")]
        public int SecteurId { get; set; }
        public Secteur Secteur { get; set; }
    }
}
