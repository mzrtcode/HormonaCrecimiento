using System.Collections.Generic;
using HormonaCrecimiento.App.Dominio;

namespace HormonaCrecimiento.App.Persistencia
{
    public class RepositorioFamiliar : IRepositorioFamiliar
    {
        private readonly AppContext _appContext;

        public RepositorioFamiliar(AppContext appContext)
        {
            _appContext = appContext;
        }

        public IEnumerable<Familiar> GetAllFamiliares()
        {
            return _appContext.Familiares;

        }

        public Familiar AddFamiliar(Familiar familiar)
        {
            var familiarAdicionar = _appContext.Familiares.Add(familiar);
            _appContext.SaveChanges();
            return familiarAdicionar.Entity;

        }
        public Familiar UpdateFamiliar(Familiar familiar)
        {
            var familiarEncontrado = _appContext.Familiares.FirstOrDefault(p => p.Id == familiar.Id);

            if (familiarEncontrado != null)
            {
                familiarEncontrado.Nombre = familiar.Nombre;
                familiarEncontrado.Apellido = familiar.Apellido;
                familiarEncontrado.Documento = familiar.Documento;
                familiarEncontrado.Genero = familiar.Genero;

                familiarEncontrado.Parentesco = familiar.Parentesco;
                familiarEncontrado.Correo = familiar.Correo;
                familiarEncontrado.Telefono = familiar.Telefono;
                

                _appContext.SaveChanges();
            }
            return familiarEncontrado;
        }
        public bool DeleteFamiliar(int idFamiliar){
            
            var familiarEncontrado = _appContext.Familiares.FirstOrDefault(p => p.Id == idFamiliar);

            if(familiarEncontrado== null){
                
                return false;
            }
            _appContext.Familiares.Remove(familiarEncontrado);
            _appContext.SaveChanges();
         
            return true;
        }
        public Familiar GetFamiliar(int idFamiliar){
            return _appContext.Familiares.FirstOrDefault(p=> p.Id == idFamiliar);
        }
    }
}