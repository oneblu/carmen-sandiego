using ConsoleApp1;

namespace ConsoleSesion3.ConceptoSealed;

// No se puede heredar
// public class Gato: AnimalSealed
class Gato
{
    public void SetAnimal()
    {
        // Ejemplo de que si se puede instanciar
        var animal = new AnimalSealed();
        animal.Nombre = "Gato";
        animal.Familia = "Felinos";
    }
}