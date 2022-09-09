using Microsoft.EntityFrameworkCore;
using HormonaCrecimiento.App.Dominio;

namespace HormonaCrecimiento.App.Persistencia;

public class AppContext:DbContext
{

    public DbSet<Persona> Personas{ get; set;}
    public DbSet<Medico> Medicos{ get; set;}
    public DbSet<Familiar> Familiares{ get; set;}
    
    public DbSet<Tratamiento> Tratamientos{ get; set;}
    public DbSet<HistoriaClinica> Historias{ get; set;}

    public DbSet<PatronCrecimiento> PatronesCrecimiento{ get; set;} 
    public DbSet<Paciente> Pacientes{ get; set;}




    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            if (!optionsBuilder.IsConfigured){
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HormonaCrecimiento ;Integrated Security=True");
    }
    }


}
