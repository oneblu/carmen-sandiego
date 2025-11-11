namespace ConsoleSesion3._1_1_Composicion;

public class Motor
{
    public string Tipo { get; set; }
    public int CaballosFuerza { get; set; }
    
    public Motor(string tipo, int caballosFuerza)
    {
        Tipo = tipo;
        CaballosFuerza = caballosFuerza;
    }
}