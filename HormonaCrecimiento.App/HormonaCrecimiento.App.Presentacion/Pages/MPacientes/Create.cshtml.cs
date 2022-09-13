using System; //AGREGAR ESTA LINEA
using System.Collections.Generic; //AGREGAR ESTA LINEA
using System.Linq; //AGREGAR ESTA LINEA
using System.Threading.Tasks; //AGREGAR ESTA LINEA
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HormonaCrecimiento.App.Persistencia;
using HormonaCrecimiento.App.Dominio;

namespace HormonaCrecimiento.App.Pages_MPacientes
{
    public class CreateModel : PageModel
    {
        private readonly IRepositorioPacienteMemoria RepositorioPacienteMemoria;
        
        [BindProperty]

        public Paciente Paciente { get; set; }
        public CreateModel(IRepositorioPacienteMemoria RepositorioPacienteMemoria){
            this.RepositorioPacienteMemoria = RepositorioPacienteMemoria;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPostSave(){
            //if(ModelState.IsValid){
                Paciente = RepositorioPacienteMemoria.Add(Paciente);
                return RedirectToPage("Index");
          /*   }else{
                return Page();
            } */
        }
    }
}
