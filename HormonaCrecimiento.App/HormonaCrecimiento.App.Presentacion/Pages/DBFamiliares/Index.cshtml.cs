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
    public class IndexModel : PageModel
    {

        private readonly IRepositorioFamiliar RepositorioFamiliar;
        public IEnumerable<Familiar> familiares { get;  set;}

        public IndexModel(IRepositorioFamiliar RepositorioFamiliar){
            this.RepositorioFamiliar = RepositorioFamiliar;
        }
        public void OnGet()
        {
            familiares = RepositorioFamiliar.GetAllFamiliares();
        }
    }
}
