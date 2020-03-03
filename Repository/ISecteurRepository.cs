using TP_Groupe.Models;

namespace TP_Groupe.Repository
{
    public interface ISecteurRepository
    {
        void Insert(Secteur secteur);
        void Update(Secteur secteur);
        void Remove(Secteur secteur);
        Secteur GetById(int Id);

    }
}
