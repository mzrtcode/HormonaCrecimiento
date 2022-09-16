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
    public class IndexModel : PageModel
    {
        private readonly IRepositorioPaciente RepositorioPaciente;
        public Paciente Paciente { get;  set;}
        //Creamos la variable para hacer uso de ese repositorio

        public IEnumerable<Paciente> pacientes { get;  set;}

        //Crear metodo constructor
        public IndexModel(IRepositorioPaciente RepositorioPaciente){
                this.RepositorioPaciente = RepositorioPaciente;
        }
        public void OnGet()
        {
            pacientes = RepositorioPaciente.GetAllPacientes();
            
        }
        
        public void traerPaciente(int idPaciente){
            Paciente = RepositorioPaciente.GetPaciente(idPaciente);
        }

       
        
    }
}
