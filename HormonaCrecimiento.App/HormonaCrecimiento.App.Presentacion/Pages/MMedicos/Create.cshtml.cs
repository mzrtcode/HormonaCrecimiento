using System; //AGREGAR ESTA LINEA
using System.Collections.Generic; //AGREGAR ESTA LINEA
using System.Linq; //AGREGAR ESTA LINEA
using System.Threading.Tasks; //AGREGAR ESTA LINEA
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HormonaCrecimiento.App.Persistencia;
using HormonaCrecimiento.App.Dominio;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HormonaCrecimiento.App.Pages_MMedicos
{
    public class CreateModel : PageModel
    {

        private readonly IRepositorioMedicoMemoria RepositorioMedicoMemoria;

        [BindProperty]

        public Medico Medico { get; set; }
        public void OnGet()
        {
        }

        public CreateModel(IRepositorioMedicoMemoria RepositorioMedicoMemoria)
        {
            this.RepositorioMedicoMemoria = RepositorioMedicoMemoria;
        }

        public IActionResult OnPostSave()
        {
            //if(ModelState.IsValid){
            Medico = RepositorioMedicoMemoria.Add(Medico);
            return RedirectToPage("Index");
            /*   }else{
                  return Page();
              } */
        }
    }
}
