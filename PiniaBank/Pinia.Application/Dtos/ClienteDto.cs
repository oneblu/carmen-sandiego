namespace Pinia.Application.Dtos;

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class ClienteDto
{
    public int Id { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string NumeroIdentificacion { get; set; }
}