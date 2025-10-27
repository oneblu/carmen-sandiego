namespace ConsoleSesion3._2_Asociaciones;

// Asociación bidireccional
public class Profesor
{
    public string Nombre { get; set; }
    public List<Curso> Cursos { get; set; }
    
    public Profesor(string nombre)
    {
        Nombre = nombre;
        Cursos = new List<Curso>();
    }
    
    public void AsignarCurso(Curso curso)
    {
        Cursos.Add(curso);
        curso.Profesor = this; // Establece la relación bidireccional
    }
}