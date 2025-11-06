namespace Pinia.Domain.Entidades;

public sealed class Cliente
{
    public int Id { get; set; }

    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string? NumeroIdentificacion { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public char Sexo { get; set; }
    public string Direccion { get; set; }
    public string Ciudad { get; set; }

    public bool Estado { get; set; }
}