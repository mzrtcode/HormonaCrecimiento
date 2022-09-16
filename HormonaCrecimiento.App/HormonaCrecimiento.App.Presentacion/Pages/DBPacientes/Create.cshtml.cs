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
    public class CreateModel : PageModel
    {
        private readonly IRepositorioPaciente RepositorioPaciente;
        
        [BindProperty]

        public Paciente Paciente { get; set; }
        public CreateModel(IRepositorioPaciente RepositorioPaciente){
            this.RepositorioPaciente = RepositorioPaciente;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPostSave(){
            //if(ModelState.IsValid){
                Paciente = RepositorioPaciente.AddPaciente(Paciente);
                return RedirectToPage("Index");
          /*   }else{
                return Page();
            } */
        }
    }
}
