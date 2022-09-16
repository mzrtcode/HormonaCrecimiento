using System; //AGREGAR ESTA LINEA
using System.Collections.Generic; //AGREGAR ESTA LINEA
using System.Linq; //AGREGAR ESTA LINEA
using System.Threading.Tasks; //AGREGAR ESTA LINEA
using HormonaCrecimiento.App.Persistencia; //AGREGAR ESTA LINEA
using HormonaCrecimiento.App.Dominio; //AGREGAR ESTA LINEA
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HormonaCrecimiento.App.Pages_MFamiliares
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioFamiliarMemoria RepositorioFamiliarMemoria;
        //Creamos la variable para hacer uso de ese repositorio

        public IEnumerable<Familiar> familiares { get;  set;}

        //Crear metodo constructor
        public EditModel(IRepositorioFamiliarMemoria RepositorioFamiliarMemoria){
                this.RepositorioFamiliarMemoria = RepositorioFamiliarMemoria;
        }
        public void OnGet()
        {
            familiares = RepositorioFamiliarMemoria.GetAll();
        }
    }
}
