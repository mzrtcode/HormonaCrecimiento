using System; //AGREGAR ESTA LINEA
using System.Collections.Generic; //AGREGAR ESTA LINEA
using System.Linq; //AGREGAR ESTA LINEA
using System.Threading.Tasks; //AGREGAR ESTA LINEA
using HormonaCrecimiento.App.Persistencia; //AGREGAR ESTA LINEA
using HormonaCrecimiento.App.Dominio; //AGREGAR ESTA LINEA
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HormonaCrecimiento.App.Pages_DBPacientes
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioPaciente RepositorioPaciente;
        //Creamos la variable para hacer uso de ese repositorio

        public Paciente Paciente { get;  set;}

        //Crear metodo constructor
        public DetailsModel(IRepositorioPaciente RepositorioPaciente){
                this.RepositorioPaciente = RepositorioPaciente;
        }
        public IActionResult OnGet(int id)
        {
            Paciente = RepositorioPaciente.GetPaciente(id);
            if(Paciente == null){
                return RedirectToPage("./NotFound");
            }else{
                return Page();
            }
        }
    }
}
