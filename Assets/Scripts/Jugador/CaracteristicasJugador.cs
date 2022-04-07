using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

  [Serializable]
public class CaracteristicasJugador 
{
    //Valor Base de Inicio del Jugador
    public float ValorBase;
    public float Costes;
    public float _Valor;
    protected bool isSucio = true;
    protected float ultimaBaseValor = float.MinValue;
    protected readonly List<ModificadorEstadistica> modificadorEstadisticas;
    public readonly ReadOnlyCollection<ModificadorEstadistica> ModificadorEstadisticas;
    public virtual float Valor
    {
        get
        {
            if (isSucio || ValorBase != ultimaBaseValor)
            {
                ultimaBaseValor = ValorBase;
                _Valor = CalcularFinalValor();
                isSucio = false;
            }
            return _Valor;
        }
    }
   
    public CaracteristicasJugador()
    {

        modificadorEstadisticas = new List<ModificadorEstadistica>();
        ModificadorEstadisticas = modificadorEstadisticas.AsReadOnly();
    }

    public CaracteristicasJugador(float valorBase) : this()
    {
        ValorBase = valorBase;
    }
    //Esta funcion es para agregar una modificacion segun la que se necesite
    public virtual void AgregarModificador(ModificadorEstadistica mod)
    {
        isSucio = true;
        modificadorEstadisticas.Add(mod);
        modificadorEstadisticas.Sort(ComparandoModificadorOrden);
    }
    protected virtual int ComparandoModificadorOrden(ModificadorEstadistica a, ModificadorEstadistica b)
    {
        if (a.Orden < b.Orden)

            return -1;

        else if (a.Orden > b.Orden)

            return 1;


        return 0;
    }
   
    //Esta funcion calcula el valor final segun el modificador (entero,porcentaje)
    protected virtual float CalcularFinalValor()
    {
        float valorFinal = ValorBase;
        float sumAgregandoPorcentaje = 0;
        for (int i = 0; i < modificadorEstadisticas.Count; i++)
        {
            ModificadorEstadistica mod = modificadorEstadisticas[i];
            if (mod.Tipo == TipoModoEstadistica.Entero)
            {
                valorFinal += +mod.Valor;
            }
            else if (mod.Tipo == TipoModoEstadistica.PorcentajeMultiple)
            {
                valorFinal *= 1 + mod.Valor;
            }
            else if (mod.Tipo == TipoModoEstadistica.PorcentajeAgregado)
            {
                sumAgregandoPorcentaje += mod.Valor;
                if (i + 1 >= modificadorEstadisticas.Count || modificadorEstadisticas[i + 1].Tipo != TipoModoEstadistica.PorcentajeAgregado)
                {
                    valorFinal *= 1 + sumAgregandoPorcentaje;
                    sumAgregandoPorcentaje = 0;
                }

            }

        }
        return (int)Math.Round(valorFinal, 4);
    }
}
