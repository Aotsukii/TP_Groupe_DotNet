using TP_Groupe.Models;

namespace TP_Groupe.Repository
{
    public interface IPositionMagasinRepository
    {
        void Insert(PositionMagasin positionMagasin);
        void Update(PositionMagasin positionMagasin);
        void Remove(PositionMagasin positionMagasin);
        PositionMagasin GetById(int Id);

    }
}
