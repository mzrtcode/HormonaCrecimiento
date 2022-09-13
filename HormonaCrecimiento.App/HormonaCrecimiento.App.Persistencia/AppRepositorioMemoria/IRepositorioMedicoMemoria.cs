using System.Collections.Generic;
using HormonaCrecimiento.App.Dominio;

namespace HormonaCrecimiento.App.Persistencia
{
    public interface IRepositorioMedicoMemoria
    {
        IEnumerable<Medico> GetAll();
        Medico Add(Medico medico);
        Medico Update(Medico medico);
        bool Delete(int idMedico);
        Medico Get(int idMedico);

    }
}