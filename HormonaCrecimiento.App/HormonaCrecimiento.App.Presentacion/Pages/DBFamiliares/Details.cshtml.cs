using System.Collections.Generic; //AGREGAR ESTA LINEA
using System.Linq; //AGREGAR ESTA LINEA
using System.Threading.Tasks; //AGREGAR ESTA LINEA
using HormonaCrecimiento.App.Persistencia; //AGREGAR ESTA LINEA
using HormonaCrecimiento.App.Dominio; //AGREGAR ESTA LINEA
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HormonaCrecimiento.App.Pages_DBFamiliares
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioFamiliar RepositorioFamiliar;
        //Creamos la variable para hacer uso de ese repositorio

        public Familiar Familiar { get;  set;}

        //Crear metodo constructor
        public DetailsModel(IRepositorioFamiliar RepositorioFamiliar){
                this.RepositorioFamiliar = RepositorioFamiliar;
        }
        public IActionResult OnGet(int id)
        {
            Familiar = RepositorioFamiliar.GetFamiliar(id);
            if(Familiar == null){
                return RedirectToPage("./NotFound");
            }else{
                return Page();
            }
        }
    }
}
