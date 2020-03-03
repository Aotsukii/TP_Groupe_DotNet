using System.Collections.Generic;

namespace TP_Groupe_DotNet.Models
{
    public class Secteur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public ICollection<Etagere> Etageres { get; set; }
    }
}
