using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public MovimientoPersonaje personaje;
    public CaracteristicasJugador Health;
    public CaracteristicasJugador Damage;
    public CaracteristicasJugador Velocity;
    public CaracteristicasJugador SpeedRate;
    public CaracteristicasJugador IncKill;
    public CaracteristicasJugador IncRound;

    [SerializeField] PanelCaracteristicas panelEstadistica;

    public GestionOpciones opciones;
    // Start is called before the first frame update.
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        panelEstadistica.EstableciendoEstadisticas(Health,Damage,Velocity,SpeedRate,IncKill,IncRound);
        panelEstadistica.ActualizandoValores();
    }

    // Update is called once per frame
    void Update()
    {
       // Velocity._Valor = personaje.speed;
    }



    public void SubiendoCaracteristicaHealth()
    {
        if(opciones.cantidadAlmas >= Health.Costes)
        {
            opciones.cantidadAlmas = opciones.cantidadAlmas - Health.Costes;
            opciones.ActualizandoAlmas();
            Health.ValorBase = Health.ValorBase + 5;
            Health.Costes = Health.Costes * 1.1f;
            Health.Costes = Mathf.Round(Health.Costes);
            panelEstadistica.ActualizandoValores();
        }
            
    }
    public void SubiendoCaracteristicaDamage()
    {
        if (opciones.cantidadAlmas >= Damage.Costes)
        {
            opciones.cantidadAlmas = opciones.cantidadAlmas - Damage.Costes;
            opciones.ActualizandoAlmas();
            Damage.ValorBase = Damage.ValorBase + 2;
            Damage.Costes = Damage.Costes * 1.1f;
            Damage.Costes = Mathf.Round(Damage.Costes);
            panelEstadistica.ActualizandoValores();
        }

    }
    public void SubiendoCaracteristicaSpeedRate()
    {
            if (opciones.cantidadAlmas >= SpeedRate.Costes)
            {
                opciones.cantidadAlmas = opciones.cantidadAlmas - SpeedRate.Costes;
                opciones.ActualizandoAlmas();
                SpeedRate.ValorBase = SpeedRate.ValorBase + 1;
                SpeedRate.Costes = SpeedRate.Costes * 1.1f;
                SpeedRate.Costes = Mathf.Round(SpeedRate.Costes);
                panelEstadistica.ActualizandoValores();
            }

    }
    public void SubiendoCaracteristicaVelocity()
    {
        if (opciones.cantidadAlmas >= Velocity.Costes)
        {
            opciones.cantidadAlmas = opciones.cantidadAlmas - Velocity.Costes;
            opciones.ActualizandoAlmas();
            Velocity.ValorBase = Velocity.ValorBase + 1;
            Velocity.Costes = Velocity.Costes * 1.1f;
            Velocity.Costes = Mathf.Round(Velocity.Costes);
            panelEstadistica.ActualizandoValores();
        }

    }
    public void SubiendoCaracteristicaIncomeKill()
    {
        if (opciones.cantidadAlmas >= IncKill.Costes)
        {
            opciones.cantidadAlmas = opciones.cantidadAlmas - IncKill.Costes;
            opciones.ActualizandoAlmas();
            IncKill.ValorBase = IncKill.ValorBase + 1;
            IncKill.Costes = IncKill.Costes * 1.1f;
            IncKill.Costes = Mathf.Round(IncKill.Costes);
            panelEstadistica.ActualizandoValores();
        }
    }
    public void SubiendoCaracteristicaIncomeRound()
    {
        if (opciones.cantidadAlmas >= IncRound.Costes)
        {
            opciones.cantidadAlmas = opciones.cantidadAlmas - IncRound.Costes;
            opciones.ActualizandoAlmas();
            IncRound.ValorBase = IncRound.ValorBase + 15;
            IncRound.Costes = IncRound.Costes * 1.1f;
            IncRound.Costes = Mathf.Round(IncRound.Costes);
            panelEstadistica.ActualizandoValores();
        }
    }
}
