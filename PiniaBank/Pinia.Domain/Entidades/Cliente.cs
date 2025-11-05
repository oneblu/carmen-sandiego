using Newtonsoft.Json;

namespace Pinia.Domain.Entidades;

public sealed class Cliente
{
    [JsonProperty("id")]
    public int Id { get; set; }
    
    [JsonProperty("nombres")]
    public string Nombres { get; set; }
    
    [JsonProperty("apellidos")]
    public string Apellidos { get; set; }
    
    [JsonProperty("numero_identificacion")]
    public string? NumeroIdentificacion { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public char Sexo { get; set; }
    public string Direccion { get; set; }
    public string Ciudad { get; set; }
    
    public bool Estado { get; set; }
}