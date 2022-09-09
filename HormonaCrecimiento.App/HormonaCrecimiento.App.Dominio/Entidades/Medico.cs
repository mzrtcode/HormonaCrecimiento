namespace HormonaCrecimiento.App.Dominio;

public class Medico:Persona{
    public Especializacion? Especializacion{get;set;}
    public string? Codigo { get; set; }
    public string? Telefono { get; set; }
    public string? RegistroRetThus{ get; set; }

}