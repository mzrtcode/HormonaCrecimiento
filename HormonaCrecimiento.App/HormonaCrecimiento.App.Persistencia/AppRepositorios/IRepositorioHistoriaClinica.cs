using System.Collections.Generic;
using HormonaCrecimiento.App.Dominio;

namespace HormonaCrecimiento.App.Persistencia
{
    public interface IRepositorioHistoriaClinica
    {
        IEnumerable<HistoriaClinica> GetAllHistorias();
        HistoriaClinica AddHistoria(HistoriaClinica historia);
        HistoriaClinica UpdateHistoria(HistoriaClinica historia);
        bool DeleteHistoria(int idFamiliar);
        HistoriaClinica GetHistoria(int idHistoria);
    }

}