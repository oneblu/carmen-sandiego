// See https://aka.ms/new-console-template for more information

using ConsoleApp1;
using ConsoleApp1.EjemploStaticClass;
using ConsoleApp1.EjemploStaticMethod;


/*
 * Ejemplo de clase y metodo estatico
 */
var impuesto = Impuesto.Calcular(1000, 16);
Console.WriteLine($"El impuesto del producto es {impuesto.ToString("C")}");

/*
 * Ejemplo de clase mixta (tiene metodos o propiedades static)
 */
var impuestoIva = new ImpuestoIva();
var calculoImpuestoIva = impuestoIva.CalcularIva19(10000);
Console.WriteLine($"El impuesto del producto es {calculoImpuestoIva.ToString("C")}");

Console.WriteLine(Environment.NewLine);

/*
 * Objetos estudiantes creados a partir de la clase Estudiante que hereda de la clase Persona
 */
var estudiante1 = new Estudiante("Pepe", "Aguilar", "34324324","Ingles");
var estudiante2 = new Estudiante("Juan", "Charrasquia", "645645","Español");
var estudiante3 = new Estudiante("Pedro","Paez");

/*
 * Armo una lista de tipo Estuadiante con los objetos creados previamente
 */
var listaEstudiantes = new List<Estudiante>
{
    estudiante1,
    estudiante2,
    estudiante3,
};

/*
 * Imprimo el conteni de la lista de estudiantes
 */
Console.WriteLine($"Listado de estudiantes: {listaEstudiantes.Count}");

foreach (var estudiante in listaEstudiantes)
{
    Console.WriteLine($"{estudiante.NombreCompleto} Cod.:{estudiante.Codigo} - Curso: {estudiante.Curso}");
}

/*
 * Clase que hereda de estudiante y agrega nuevos atributos como el hobby
 */
var hijo = new HijoEstudiante
{
    Nombre = "Michael",
    Apellido = "Jackson",
    Edad = 20,
    Hobby = "Correr"
};




