namespace ConsoleSesion3._1_2_Agregacion;

public class Estudiante
{
    public string Nombre { get; set; }
    public string Matricula { get; set; }
    
    public Estudiante(string nombre, string matricula)
    {
        Nombre = nombre;
        Matricula = matricula;
    }
}