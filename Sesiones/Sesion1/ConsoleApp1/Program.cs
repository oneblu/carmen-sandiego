// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

/*
 * Aqui se crea los objetos a partir de la clase persona
 */
 var persona1 = new Persona("Pepe", "Aguilar", "paguilar@gmail.com","3123234543");
 var persona2 = new Persona("Juan", "Charrasquia", "jcharr@hotmail.com","2132343578"); 
 var persona3 = new Persona("Pedro","Paez");

Console.WriteLine($"Nombre completo de la persona 1: {persona1.NombreCompleto}");
Console.WriteLine($"Nombre de la persona 2: {persona2.Nombre}");
Console.WriteLine($"Apellido de la persona 3: {persona3.Apellido}");

Console.Write($"{Environment.NewLine}Press Enter to exit...");
Console.Read();