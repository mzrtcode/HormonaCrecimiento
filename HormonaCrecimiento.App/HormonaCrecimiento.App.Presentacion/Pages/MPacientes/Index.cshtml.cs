using System; //AGREGAR ESTA LINEA
using System.Collections.Generic; //AGREGAR ESTA LINEA
using System.Linq; //AGREGAR ESTA LINEA
using System.Threading.Tasks; //AGREGAR ESTA LINEA
using HormonaCrecimiento.App.Persistencia; //AGREGAR ESTA LINEA
using HormonaCrecimiento.App.Dominio; //AGREGAR ESTA LINEA


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HormonaCrecimiento.App.Pages_MPacientes
{
    public class IndexModel : PageModel
    {

        private readonly IRepositorioPacienteMemoria RepositorioPacienteMemoria;
        //Creamos la variable para hacer uso de ese repositorio

        public IEnumerable<Paciente> pacientes { get;  set;}

        //Crear metodo constructor
        public IndexModel(IRepositorioPacienteMemoria RepositorioPacienteMemoria){
                this.RepositorioPacienteMemoria = RepositorioPacienteMemoria;
        }
        public void OnGet()
        {
            pacientes = RepositorioPacienteMemoria.GetAll();
        }
    }
}
