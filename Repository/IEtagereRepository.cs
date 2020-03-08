using System;
using System.Collections.Generic;
using TP_Groupe.Models;

namespace TP_Groupe.Repository
{
    public interface IEtagereRepository
    {
        void Insert(Etagere etagere);
        void Update(Etagere etagere);
        void Remove(Etagere etagere);
        IEnumerable<Etagere> GetAllEtageres();
        Etagere GetById(int Id);

    }
}
