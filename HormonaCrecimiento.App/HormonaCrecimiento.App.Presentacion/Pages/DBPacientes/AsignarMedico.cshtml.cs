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
    public class AsignarMedicoModel : PageModel
    {   
        private readonly IRepositorioMedico RepositorioMedico;
        private readonly IRepositorioPaciente RepositorioPaciente;

        public IEnumerable<Medico> Medicos { get; set; }
        [BindProperty]
        public  int medicoId{ get;  set; }
        [BindProperty]
        public Medico Medico{ get;  set;}
        [BindProperty]
        public Paciente Paciente { get;  set;} 

        public AsignarMedicoModel(IRepositorioMedico RepositorioMedico, IRepositorioPaciente RepositorioPaciente){
            this.RepositorioMedico =    RepositorioMedico;
            this.RepositorioPaciente = RepositorioPaciente;
        }
        public IActionResult OnGet(int PacienteId)
        { 
            Medicos = RepositorioMedico.GetAllMedicos();
            Paciente = RepositorioPaciente.GetPaciente(PacienteId);

            if(Paciente ==null){
                return RedirectToPage("./NotFound");
            }else{
                return Page();
            }
        }

        public IActionResult OnPostToAssign(int medicoId){
            Medico =  RepositorioPaciente.SetMedico(Paciente.Id, medicoId);
            return RedirectToPage("Index");
        }
    }
}
