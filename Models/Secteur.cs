using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TP_Groupe.Models
{
    public class Secteur
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public ICollection<Etagere> Etageres { get; set; }
    }
}
