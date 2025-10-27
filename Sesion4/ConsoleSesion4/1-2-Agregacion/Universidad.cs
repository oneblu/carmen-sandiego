namespace ConsoleSesion3._1_2_Agregacion;

public class Universidad
{
    private List<Estudiante> _estudiantes; // Agregación
    
    public string Nombre { get; set; }
    
    public Universidad(string nombre)
    {
        Nombre = nombre;
        _estudiantes = new List<Estudiante>();
    }
    
    // Agregar estudiantes que ya existen
    public void MatricularEstudiante(Estudiante estudiante)
    {
        _estudiantes.Add(estudiante);
        Console.WriteLine($"Estudiante {estudiante.Nombre} matriculado en {Nombre}");
    }
    
    public void ListarEstudiantes()
    {
        foreach (var estudiante in _estudiantes)
        {
            Console.WriteLine($"- {estudiante.Nombre} ({estudiante.Matricula})");
        }
    }
}