using System; //AGREGAR ESTA LINEA
using System.Collections.Generic; //AGREGAR ESTA LINEA
using System.Linq; //AGREGAR ESTA LINEA
using System.Threading.Tasks; //AGREGAR ESTA LINEA
using HormonaCrecimiento.App.Persistencia; //AGREGAR ESTA LINEA
using HormonaCrecimiento.App.Dominio; //AGREGAR ESTA LINEA
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HormonaCrecimiento.App.Pages_DBMedicos
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioMedico RepositorioMedico;
        //Creamos la variable para hacer uso de ese repositorio

        public IEnumerable<Medico> medicos { get;  set;}

        //Crear metodo constructor
        public IndexModel(IRepositorioMedico RepositorioMedico){
                this.RepositorioMedico = RepositorioMedico;
        }
        public void OnGet()
        {
            medicos = RepositorioMedico.GetAllMedicos();
        }
    }
}
