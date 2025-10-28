// See https://aka.ms/new-console-template for more information

using ConsoleSesion3._1_1_Composicion;
using ConsoleSesion3._1_2_Agregacion;
using ConsoleSesion3._2_Asociaciones;
using ConsoleSesion3._3_2_Con_Inyeccion_Dependencias_Desacoplado;

/*
 * 1. Composición y Agregación
 */

// Composicion (Relación Fuerte - el todo controla el ciclo de vida de las partes)

// var miCarro = new Carro("Toyota", "V6", 300);
// miCarro.Encender();


// Agregación (Relación débil - las partes pueden existir independientemente)

//Creo la universidad e inicializo (objeto list) la lista de estudiantes
// var universidad = new Universidad("Universidad Nacional");

//Creo los estudiantes
// var estudiante1 = new Estudiante("María", "2023001");
// var estudiante2 = new Estudiante("Carlos", "2023002");

// universidad.MatricularEstudiante(estudiante1);
// universidad.MatricularEstudiante(estudiante2);
//
// universidad.ListarEstudiantes();

// Los estudiantes siguen existiendo aunque la universidad los elimine

/*
 * 2. Asociaciones entre Clases
 */
//var profesor = new Profesor("Dr. García");
var cursoMatemáticas = new Curso("Matemáticas", "MAT101");
var cursoFisica = new Curso("Física", "FIS101");

// profesor.AsignarCurso(cursoMatemáticas);
// profesor.AsignarCurso(cursoFisica);

cursoMatemáticas.MostrarInfo();
Console.WriteLine("----------------------------");
cursoFisica.MostrarInfo();

/*
 * 3-2 Inyección de Dependencias (Desacoplado)
 */
 
// var notificacionService = DIContainer.GetNotificacionService();
// var usuarioService = new UsuarioService(notificacionService);
// usuarioService.RegistrarUsuario("Ana García");

/*
 * 4 Responsabilidad Unica
 */
// Uso
// var usuarioServiceSrp = new ConsoleSesion3._4_Principio_Responsabilidad_Unica.Bien.UsuarioService();
// usuarioServiceSrp.RegistrarUsuario("Juan Pérez", "juan@email.com");