namespace ConsoleSesion3._4_Principio_Responsabilidad_Unica.Bien;

// Responsabilidad: Orquestación del proceso
public class UsuarioServiceSRP
{
    private readonly ValidadorUsuario _validador;
    private readonly UsuarioRepository _repository;
    private readonly NotificadorEmail _notificador;
    
    public UsuarioServiceSRP()
    {
        _validador = new ValidadorUsuario();
        _repository = new UsuarioRepository();
        _notificador = new NotificadorEmail();
    }
    
    public void RegistrarUsuario(string nombre, string email)
    {
        if (!_validador.Validar(nombre, email))
            throw new ArgumentException("Datos inválidos");
        
        _repository.Guardar(nombre, email);
        _notificador.EnviarEmailBienvenida(email);
        
        Console.WriteLine($"Usuario {nombre} registrado exitosamente");
    }
}