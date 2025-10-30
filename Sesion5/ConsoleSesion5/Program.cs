using ConsoleSesion3._4_Principio_Responsabilidad_Unica.Bien;

var usuarioServiceSrp = new UsuarioServiceSRP();

try
{
    usuarioServiceSrp.RegistrarUsuario("Juan Pérez", "juanu8uemail.com");
}
catch (Exception e)
{
    Console.WriteLine($"Ha ocurrido un error inesperado: {e.Message}");
}
finally //Halla o no halla exception siempre se ejecuta
{
    Console.WriteLine("Siempre me ejecuto: Programa finalizado");
}