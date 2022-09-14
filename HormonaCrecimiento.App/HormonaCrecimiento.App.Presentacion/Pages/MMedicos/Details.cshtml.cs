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
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioMedicoMemoria RepositorioMedicoMemoria;
        //Creamos la variable para hacer uso de ese repositorio

        public Medico Medico { get;  set;}

        //Crear metodo constructor
        public DetailsModel(IRepositorioMedicoMemoria RepositorioMedicoMemoria){
                this.RepositorioMedicoMemoria = RepositorioMedicoMemoria;
        }
        public IActionResult OnGet(int id)
        {
            Medico = RepositorioMedicoMemoria.Get(id);
            if(Medico == null){
                return RedirectToPage("./NotFound");
            }else{
                return Page();
            }
        }
    }
}
