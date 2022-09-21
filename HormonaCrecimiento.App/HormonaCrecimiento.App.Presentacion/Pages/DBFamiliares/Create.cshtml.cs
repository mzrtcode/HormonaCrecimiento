using System; //AGREGAR ESTA LINEA
using System.Collections.Generic; //AGREGAR ESTA LINEA
using System.Linq; //AGREGAR ESTA LINEA
using System.Threading.Tasks; //AGREGAR ESTA LINEA
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HormonaCrecimiento.App.Persistencia;
using HormonaCrecimiento.App.Dominio;

namespace HormonaCrecimiento.App.Pages_DBFamiliares
{
    public class CreateModel : PageModel
    {
         private readonly IRepositorioFamiliar RepositorioFamiliar;

        [BindProperty]

        public Familiar Familiar { get; set; }
        public void OnGet()
        {
        }

        public CreateModel(IRepositorioFamiliar RepositorioFamiliar)
        {
            this.RepositorioFamiliar = RepositorioFamiliar;
        }

        public IActionResult OnPostSave()
        {
            //if(ModelState.IsValid){
            Familiar = RepositorioFamiliar.AddFamiliar(Familiar);
            return RedirectToPage("Index");
            /*   }else{
                  return Page();
              } */
        }
    }
}
