using System.Collections.Generic;
using HormonaCrecimiento.App.Dominio;

namespace HormonaCrecimiento.App.Persistencia
{
    public class RepositorioMedico : IRepositorioMedico
    {
        private readonly AppContext _appContext;

        public RepositorioMedico(AppContext appContext)
        {
            _appContext = appContext;
        }

        public IEnumerable<Medico> GetAllMedicos()
        {
            return _appContext.Medicos;

        }

        public Medico AddMedico(Medico medico)
        {
            var medicoAdicionar = _appContext.Medicos.Add(medico);
            _appContext.SaveChanges();
            return medicoAdicionar.Entity;

        }
        public Medico UpdateMedico(Medico medico)
        {
            var medicoEncontrado = _appContext.Medicos.FirstOrDefault(p => p.Id == medico.Id);

            if (medicoEncontrado != null)
            {
                medicoEncontrado.Nombre = medico.Nombre;
                medicoEncontrado.Apellido = medico.Apellido;
                medicoEncontrado.Documento = medico.Documento;
                medicoEncontrado.Genero = medico.Genero;


                medicoEncontrado.Especializacion = medico.Especializacion;
                medicoEncontrado.Codigo = medico.Codigo;
                medicoEncontrado.Telefono = medico.Telefono;
                medicoEncontrado.RegistroRetThus = medico.RegistroRetThus;
                

                _appContext.SaveChanges();
            }
            return medicoEncontrado;
        }
        public bool DeleteMedico(int idMedico){
            
            var medicoEncontrado = _appContext.Medicos.FirstOrDefault(p => p.Id == idMedico);

            if(medicoEncontrado== null){
                
                return false;
            }
            _appContext.Medicos.Remove(medicoEncontrado);
            _appContext.SaveChanges();
         
            return true;
        }
        public Medico GetMedico(int idMedico){
            return _appContext.Medicos.FirstOrDefault(p=> p.Id == idMedico);
        }
    }
}