namespace HormonaCrecimiento.App.Dominio;

public class Paciente:Persona
{
    public string Direccion { get; set; }
    public float Latitud { get; set; }
    public float Longitud { get; set; }
    public string Ciudad { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public Familiar Familiar { get; set; }
        public Medico Pediatra { get; set; }
        public Medico Endocrino { get; set; }
    public System.Collections.Generic.List<PatronCrecimiento> PatronesCrecimiento { get; set;}
    public HistoriaClinica HistoriaClinica { get; set; }
}
