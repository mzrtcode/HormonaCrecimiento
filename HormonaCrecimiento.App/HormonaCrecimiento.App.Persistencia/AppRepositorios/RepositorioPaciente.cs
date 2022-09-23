using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using HormonaCrecimiento.App.Dominio;

namespace HormonaCrecimiento.App.Persistencia
{
    public class RepositorioPaciente : IRepositorioPaciente
    {
        private readonly AppContext _appContext;

        public RepositorioPaciente(AppContext appContext)
        {
            _appContext = appContext;
        }

        public IEnumerable<Paciente> GetAllPacientes()
        {
            return _appContext.Pacientes;

        }

        public Paciente AddPaciente(Paciente paciente)
        {
            var pacienteAdicionar = _appContext.Pacientes.Add(paciente);
            _appContext.SaveChanges();
            return pacienteAdicionar.Entity;

        }
        public Paciente UpdatePaciente(Paciente paciente)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == paciente.Id);

            if (pacienteEncontrado != null)
            {
                pacienteEncontrado.Nombre = paciente.Nombre;
                pacienteEncontrado.Apellido = paciente.Apellido;
                pacienteEncontrado.Documento = paciente.Documento;
                pacienteEncontrado.Genero = paciente.Genero;


                pacienteEncontrado.Direccion = paciente.Direccion;
                pacienteEncontrado.Latitud = paciente.Latitud;
                pacienteEncontrado.Longitud = paciente.Longitud;
                pacienteEncontrado.Ciudad = paciente.Ciudad;
                pacienteEncontrado.FechaNacimiento = paciente.FechaNacimiento;
                pacienteEncontrado.Familiar = paciente.Familiar;
                pacienteEncontrado.Medico = paciente.Medico;
                pacienteEncontrado.HistoriaClinica = paciente.HistoriaClinica;

                _appContext.SaveChanges();
            }
            return pacienteEncontrado;
        }
        public bool DeletePaciente(int idPaciente)
        {

            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);

            if (pacienteEncontrado == null)
            {

                return false;
            }
            _appContext.Pacientes.Remove(pacienteEncontrado);
            _appContext.SaveChanges();

            return true;
        }
        public Paciente GetPaciente(int idPaciente)
        {
            return _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
        }


        public Medico SetMedico(int idPaciente, int idMedico)
        {
            var paciente = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);

            if (paciente != null)
            {
                var medico = _appContext.Medicos.FirstOrDefault(m => m.Id == idMedico);

                if (medico != null)
                {
                    paciente.Medico = medico;
                    _appContext.SaveChanges();

                }
                return medico;

            }

            return null;
        }



        public Familiar SetFamiliar(int idPaciente, int idFamiliar)
        {
            var paciente = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
            if (paciente != null)
            {
                var familiar = _appContext.Familiares.FirstOrDefault(f => f.Id == idFamiliar);

                if (familiar != null)
                {
                    paciente.Familiar = familiar;
                    _appContext.SaveChanges();

                }
                return familiar;

            }

            return null;
        }


        public HistoriaClinica SetHistoriaClinica(int idPaciente, int idHistoriaClinica)
        {
            var paciente = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
            if (paciente != null)
            {
                var historia = _appContext.Historias.FirstOrDefault(h => h.Id == idHistoriaClinica);

                if (historia != null)
                {
                    paciente.HistoriaClinica = historia;
                    _appContext.SaveChanges();

                }
                return historia;

            }

            return null;
        }

        public Medico ConsultarMedico(int idpaciente){
            var paciente = _appContext.Pacientes.Where(p=> p.Id==idpaciente).Include(p => p.Medico).FirstOrDefault();
            return paciente.Medico;
        }

       /*  public IEnumerable<PatronCrecimiento> GetPatronesCrecimiento (int idpaciente){
             var paciente = _appContext.Pacientes.Where(p=> p.Id==idpaciente).Include(p => p.PatronesCrecimiento).FirstOrDefault();
             return _appContext.PatronesCrecimiento.Where(p=> p.Id==idpaciente).ToList();
       
        }
 */

        public IEnumerable<PatronCrecimiento> GetPatronesCrecimiento (int idpaciente){
             var paciente = _appContext.Pacientes.Where(p=> p.Id==idpaciente).Include(p => p.PatronesCrecimiento).FirstOrDefault();
            return paciente.PatronesCrecimiento;
        }
       public IEnumerable<Paciente> PacientesMedico (int idmedico){
             
            return _appContext.Pacientes.Where(p => p.Medico.Id==idmedico).ToList();
        }

 




    }
}