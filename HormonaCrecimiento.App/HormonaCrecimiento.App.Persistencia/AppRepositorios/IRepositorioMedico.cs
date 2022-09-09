using System.Collections.Generic;
using HormonaCrecimiento.App.Dominio;

namespace HormonaCrecimiento.App.Persistencia
{
    public interface IRepositorioMedico
    {
        IEnumerable<Medico> GetAllMedicos();
        Medico AddMedico(Medico Medico);
        Medico UpdateMedico(Medico Medico);
        bool DeleteMedico(int idMedico);
        Medico GetMedico(int idMedico);
    }
}