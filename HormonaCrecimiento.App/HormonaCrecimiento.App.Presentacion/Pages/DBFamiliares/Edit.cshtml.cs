using System; //AGREGAR ESTA LINEA
using System.Collections.Generic; //AGREGAR ESTA LINEA
using System.Linq; //AGREGAR ESTA LINEA
using System.Threading.Tasks; //AGREGAR ESTA LINEA
using HormonaCrecimiento.App.Persistencia; //AGREGAR ESTA LINEA
using HormonaCrecimiento.App.Dominio; //AGREGAR ESTA LINEA
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HormonaCrecimiento.App.Pages_DBFamiliares
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioFamiliar RepositorioFamiliar;
        
        [BindProperty]
        public Familiar Familiar { get; set; }
        public EditModel(IRepositorioFamiliar RepositorioFamiliar){
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

        public IActionResult OnPostUpdate(){
            //if(ModelState.IsValid){
                Familiar = RepositorioFamiliar.UpdateFamiliar(Familiar);
                return RedirectToPage("Index");
          /*   }else{
                return Page();
            } */
        }
    }
}
