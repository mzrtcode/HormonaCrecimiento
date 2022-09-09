namespace HormonaCrecimiento.App.Dominio;

public class HistoriaClinica
{
    public int Id { get; set; }
    public string Diagnostico { get; set; }
    public System.Collections.Generic.List<Tratamiento> Tratamientos { get; set;}
}
