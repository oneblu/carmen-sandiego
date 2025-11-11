namespace ConsoleApp1;

public class Estudiante : Persona
{
    public string Hobby { get; set; }

    public string Curso { get; set; }
    public string Codigo { get; set; }

    public decimal Nota1 { get; private set; }
    public decimal Nota2 { get; private set; }
    public decimal Nota3 { get; set; }
    
    public void SetNota1(decimal nota1)
    {
        Nota1 = nota1;
    }

    public decimal GetPromedio()
    {
        return (Nota1 + Nota2+ Nota3) / 3;
    }

    public Estudiante()
    {
    }

    public Estudiante(string nombre, string apellido) : base(nombre, apellido)
    {
    }

    public Estudiante(string nombre, string apellido, string codigo, string curso) : base(nombre, apellido)
    {
        Codigo = codigo;
        Curso = curso;
    }
}