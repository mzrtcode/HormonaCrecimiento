using System.Collections.Generic;
using HormonaCrecimiento.App.Dominio;

namespace HormonaCrecimiento.App.Persistencia
{
    public class RepositorioHistoriaClinica : IRepositorioHistoriaClinica
    {
        private readonly AppContext _appContext;

        public RepositorioHistoriaClinica(AppContext appContext)
        {
            _appContext = appContext;
        }

        public IEnumerable<HistoriaClinica> GetAllHistorias()
        {
            return _appContext.Historias;

        }

        public HistoriaClinica AddHistoria(HistoriaClinica historia)
        {
            var HistoriaClinicaAdicionar = _appContext.Historias.Add(historia);
            _appContext.SaveChanges();
            return HistoriaClinicaAdicionar.Entity;

        }
        public HistoriaClinica UpdateHistoria(HistoriaClinica historia)
        {
            var HistoriaClinicaEncontrado = _appContext.Historias.FirstOrDefault(h => h.Id == historia.Id);

            if (HistoriaClinicaEncontrado != null)
            {
                HistoriaClinicaEncontrado.Diagnostico = historia.Diagnostico;
                HistoriaClinicaEncontrado.Tratamientos = historia.Tratamientos;
                

                _appContext.SaveChanges();
            }
            return HistoriaClinicaEncontrado;
        }
        public bool DeleteHistoria(int idHistoriaClinica){
            
            var HistoriaClinicaEncontrado = _appContext.Historias.FirstOrDefault(h => h.Id == idHistoriaClinica);

            if(HistoriaClinicaEncontrado== null){
                
                return false;
            }
            _appContext.Historias.Remove(HistoriaClinicaEncontrado);
            _appContext.SaveChanges();
         
            return true;
        }
        public HistoriaClinica GetHistoria(int idHistoriaClinica){
            return _appContext.Historias.FirstOrDefault(h=> h.Id == idHistoriaClinica);
        }
    }
}