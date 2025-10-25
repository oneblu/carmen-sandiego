// See https://aka.ms/new-console-template for more information

using ConsoleSesion3;
using ConsoleSesion3.ConceptoAbstract;
using ConsoleSesion3.ConceptoInterfaces;

Console.WriteLine("=== DEMOSTRACIÓN DE POLIMORFISMO ===\n");


// Crear una lista de figuras (polimorfismo en acción)
var figuras = new Figura[]
{
    new Circulo(5),
    new Rectangulo(4, 6),
    new Triangulo(12, 8),
    new Circulo(3.5),
    new Rectangulo(10, 2)
};

// Procesar todas las figuras de la misma manera
foreach (var figura in figuras)
{
    figura.MostrarInformacion();
}

Console.WriteLine($"\n=== CÁLCULO DEL ÁREA TOTAL ===");
        
double areaTotal = 0;
foreach (var figura in figuras)
{
    areaTotal += figura.CalcularArea();
}
        
Console.WriteLine($"Área total de todas las figuras: {areaTotal:F2}");

// Demostración adicional con métodos que aceptan la clase base
Console.WriteLine($"\n=== PROCESAMIENTO INDIVIDUAL ===");
ProcesarFigura(new Circulo(7));
ProcesarFigura(new Rectangulo(5, 5));
ProcesarFigura(new Triangulo(6, 4));

// Método que puede trabajar con CUALQUIER figura (polimorfismo)
static void ProcesarFigura(Figura figura)
{
    Console.WriteLine($"Procesando figura...");
    figura.MostrarInformacion();
    Console.WriteLine($"Tipo concreto: {figura.GetType().Name}");
    Console.WriteLine("---");
}

/*
 * Uso de interfaces
 */

var cliente = new Cliente()
{
    Nombre = "Pepe",
    Apellido = "Cortisona",
    Correo = "pcortisona@gmail.com",
    Telefono = "3213452343"
};

var proveedor = new Proveedor()
{
    Nombre = "ProveedorX",
    Apellido = "Peres",
    Correo = "erwer@gmail.com",
    Telefono = "45435345435"
};

var dbCliente = new DbContacto();
 var exitoCliente = dbCliente.CrearCliente(cliente);
 var exitoProveedor = dbCliente.CrearCliente(proveedor);
 
if (exitoCliente)
 {
     Console.Write("Cliente guardado con exito!");
 }