namespace HormonaCrecimiento.App.Dominio;

public class PatronCrecimiento
{
    public int Id { get; set; }
    public DateTime FechaHora{ get; set; }
    public float Valor { get; set; }
    public TipoPatron TipoPatron { get; set; }
}
