namespace ConsoleSesion3._2_Asociaciones;

public class Curso
{
    public string Nombre { get; set; }
    public string Codigo { get; set; }
    public Profesor Profesor { get; set; } // Asociación
    
    public Curso(string nombre, string codigo)
    {
        Nombre = nombre;
        Codigo = codigo;
    }
    
    public void MostrarInfo()
    {
        Console.WriteLine($"Curso: {Nombre} ({Codigo})");
        if (Profesor != null)
        {
            Console.WriteLine($"Profesor: {Profesor.Nombre}");
        }
    }
}