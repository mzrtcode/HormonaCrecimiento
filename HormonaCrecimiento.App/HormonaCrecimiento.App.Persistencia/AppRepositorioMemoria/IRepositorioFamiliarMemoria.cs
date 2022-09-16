using System.Collections.Generic;
using HormonaCrecimiento.App.Dominio;

namespace HormonaCrecimiento.App.Persistencia
{
    public interface IRepositorioFamiliarMemoria
    {
        IEnumerable<Familiar> GetAll();
        Familiar Add(Familiar paciente);
        Familiar Update(Familiar paciente);
        bool Delete(int idFamiliar);
        Familiar Get(int idFamiliar);

    }
}