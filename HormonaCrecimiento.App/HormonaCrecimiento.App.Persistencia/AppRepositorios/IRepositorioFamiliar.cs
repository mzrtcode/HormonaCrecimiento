using System.Collections.Generic;
using HormonaCrecimiento.App.Dominio;

namespace HormonaCrecimiento.App.Persistencia
{
    public interface IRepositorioFamiliar
    {
        IEnumerable<Familiar> GetAllFamiliares();
        Familiar AddFamiliar(Familiar Familiar);
        Familiar UpdateFamiliar(Familiar Familiar);
        bool DeleteFamiliar(int idFamiliar);
        Familiar GetFamiliar(int idFamiliar);
    }
}