using System.Collections.Generic; //AGREGAR ESTA LINEA
using System.Linq; //AGREGAR ESTA LINEA
using System.Threading.Tasks; //AGREGAR ESTA LINEA
using HormonaCrecimiento.App.Persistencia; //AGREGAR ESTA LINEA
using HormonaCrecimiento.App.Dominio; //AGREGAR ESTA LINEA
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HormonaCrecimiento.App.Pages_MFamiliares
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioFamiliarMemoria RepositorioFamiliarMemoria;
        //Creamos la variable para hacer uso de ese repositorio

        public Familiar Familiar { get;  set;}

        //Crear metodo constructor
        public DetailsModel(IRepositorioFamiliarMemoria RepositorioFamiliarMemoria){
                this.RepositorioFamiliarMemoria = RepositorioFamiliarMemoria;
        }
        public IActionResult OnGet(int id)
        {
            Familiar = RepositorioFamiliarMemoria.Get(id);
            if(Familiar == null){
                return RedirectToPage("./NotFound");
            }else{
                return Page();
            }
        }
    }
}
