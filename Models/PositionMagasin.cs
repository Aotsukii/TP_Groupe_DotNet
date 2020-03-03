namespace TP_Groupe_DotNet.Models
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
