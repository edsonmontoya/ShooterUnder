
public enum TipoModoEstadistica
{
    Entero = 100,
    PorcentajeAgregado = 200,
    PorcentajeMultiple = 300,

}


public class ModificadorEstadistica
{
    public readonly float Valor;
    public readonly TipoModoEstadistica Tipo;
    public readonly int Orden;
    public readonly object Fuente;
    public ModificadorEstadistica(float valor, TipoModoEstadistica tipo, int orden, object fuente)
    {
        Valor = valor;
        Tipo = tipo;
        Orden = orden;
        Fuente = fuente;
    }
    public ModificadorEstadistica(float valor, TipoModoEstadistica tipo) : this(valor, tipo, (int)tipo) { }
    public ModificadorEstadistica(float valor, TipoModoEstadistica tipo, int orden) : this(valor, tipo, orden, null) { }
    public ModificadorEstadistica(float valor, TipoModoEstadistica tipo, object fuente) : this(valor, tipo, (int)tipo, fuente) { }

}