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
    public class EditModel : PageModel
    {
         private readonly IRepositorioPaciente RepositorioPaciente;
        
        [BindProperty]

        public Paciente Paciente { get; set; }
        public EditModel(IRepositorioPaciente RepositorioPaciente){
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

        public IActionResult OnPostUpdate(){
            //if(ModelState.IsValid){
                Paciente = RepositorioPaciente.UpdatePaciente(Paciente);
                return RedirectToPage("Index");
          /*   }else{
                return Page();
            } */
        }
    }
}
