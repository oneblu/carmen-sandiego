using ConsoleSesion3.Generica;
using ConsoleSesion3.Generica2;

var cajaDeNumeros = new Caja<int>(123); 
var cajaDeCadenas = new Caja<string>("Hola Mundo");

var clientes =new List<Cliente>(){
    new Cliente()
    {
        Id = 1,
        Nombre = "Carlos",
    },
    new Cliente()
    {
        Id = 2,
        Nombre = "Juan",
    }
};

var cajaDeListaDeClientes = new Caja<List<Cliente>>(clientes);

var muestraClientes = cajaDeListaDeClientes.ObtenerContenido();
cajaDeListaDeClientes.MostrarTipo();

// var numero = cajaDeNumeros.ObtenerContenido(); 
// Console.WriteLine(numero);
//
// var texto = cajaDeCadenas.ObtenerContenido();
// Console.WriteLine(texto);
//
// cajaDeCadenas.MostrarTipo();