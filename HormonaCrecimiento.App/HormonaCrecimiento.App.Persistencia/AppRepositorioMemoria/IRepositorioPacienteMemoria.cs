using System.Collections.Generic;
using HormonaCrecimiento.App.Dominio;

namespace HormonaCrecimiento.App.Persistencia
{
    public interface IRepositorioPacienteMemoria
    {
        IEnumerable<Paciente> GetAll();
        Paciente Add(Paciente paciente);
        Paciente Update(Paciente paciente);
        bool Delete(int idPaciente);
        Paciente Get(int idPaciente);

    }
}