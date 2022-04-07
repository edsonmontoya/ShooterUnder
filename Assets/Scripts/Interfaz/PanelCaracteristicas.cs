using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelCaracteristicas : MonoBehaviour
{
    public StatusPanel statusPanels;
    public Stats characters;
    public CaracteristicasJugador[] Estadisticas;
    [SerializeField] EstadisticaDisplay[] EstadisticasDisplays;
    [SerializeField] string[] nombresEstadisticas;
    [SerializeField] int[] costesEstadisticas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ActualizandoCostes();
    }
    private void OnValidate()
    {
        EstadisticasDisplays = GetComponentsInChildren<EstadisticaDisplay>();
        ActualizandoValores();
       


    }
    public void EstableciendoEstadisticas(params CaracteristicasJugador[] charStats)
    {
        Estadisticas = charStats;
        if (Estadisticas.Length > EstadisticasDisplays.Length)
        {
            return;
        }
        for (int i = 0; i < Estadisticas.Length; i++)
        {
            EstadisticasDisplays[i].gameObject.SetActive(i < EstadisticasDisplays.Length);
        }
    }
    public void ActualizandoValores()
    {
        for (int i = 0; i < Estadisticas.Length; i++)
        {
            EstadisticasDisplays[i].valorText.text = Estadisticas[i].Valor.ToString();
        }
        //Aqui hacemos que el slider se actualice conforme la salud maxima entre la actual
       // statusPanels.healthLabel.text = $"{Mathf.RoundToInt(characters.Health._Valor)}/{Mathf.RoundToInt(characters.HealthActual._Valor)}";
    }
    public void ActualizandoNombreEstadistica()
    {
        for (int i = 0; i < nombresEstadisticas.Length; i++)
        {
            EstadisticasDisplays[i].nametext.text = nombresEstadisticas[i];
        }
    }
    public void ActualizandoCostes()
    {
        for (int i = 0; i < costesEstadisticas.Length; i++)
        {
            EstadisticasDisplays[i].costeText.text = Estadisticas[i].Costes.ToString();
        }
    }
}
