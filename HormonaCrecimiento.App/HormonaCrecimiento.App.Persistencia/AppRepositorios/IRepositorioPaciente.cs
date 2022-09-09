using System.Collections.Generic;
using HormonaCrecimiento.App.Dominio;

namespace HormonaCrecimiento.App.Persistencia
{
    public interface IRepositorioPaciente
    {
        IEnumerable<Paciente> GetAllPacientes();
        Paciente AddPaciente(Paciente paciente);
        Paciente UpdatePaciente(Paciente paciente);
        bool DeletePaciente(int idPaciente);
        Paciente GetPaciente(int idPaciente);

        Medico SetMedico(int idPaciente, int idMedico);

        Familiar SetFamiliar(int idPaciente, int idFamiliar);
        HistoriaClinica SetHistoriaClinica(int idPaciente, int idHistoriaClinica);

    }
}