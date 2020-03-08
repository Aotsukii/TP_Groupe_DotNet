using System;
using System.Collections.Generic;
using TP_Groupe.Models;

namespace TP_Groupe.Repository
{
    public interface ISecteurRepository
    {
        void Insert(Secteur secteur);
        void Update(Secteur secteur);
        void Remove(Secteur secteur);
        IEnumerable<Secteur> GetAllSecteurs();
        Secteur GetById(int Id);

    }
}
