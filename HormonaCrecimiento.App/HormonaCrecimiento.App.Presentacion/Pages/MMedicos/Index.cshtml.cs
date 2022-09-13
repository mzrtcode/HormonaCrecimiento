using System; //AGREGAR ESTA LINEA
using System.Collections.Generic; //AGREGAR ESTA LINEA
using System.Linq; //AGREGAR ESTA LINEA
using System.Threading.Tasks; //AGREGAR ESTA LINEA
using HormonaCrecimiento.App.Persistencia; //AGREGAR ESTA LINEA
using HormonaCrecimiento.App.Dominio; //AGREGAR ESTA LINEA
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HormonaCrecimiento.App.Pages_MMedicos
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioMedicoMemoria RepositorioMedicoMemoria;
        //Creamos la variable para hacer uso de ese repositorio

        public IEnumerable<Medico> medicos { get;  set;}

        //Crear metodo constructor
        public IndexModel(IRepositorioMedicoMemoria RepositorioMedicoMemoria){
                this.RepositorioMedicoMemoria = RepositorioMedicoMemoria;
        }
        public void OnGet()
        {
            medicos = RepositorioMedicoMemoria.GetAll();
        }
    }
}
