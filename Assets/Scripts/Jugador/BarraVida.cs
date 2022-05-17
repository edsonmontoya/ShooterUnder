using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Stats stats;
    public Slider Barra;
    public Text Vida;

    void Start()
    {
        stats.ActualHealth._Valor = stats.Health.ValorBase;
    }

    // Update is called once per frame
    void Update()
    {
        EstableciendoSalud();
        this.Barra.value = stats.ActualHealth._Valor / stats.Health.ValorBase;
    }

    public void EstableciendoSalud()
    {
        Vida.text = stats.ActualHealth._Valor + "/" + stats.Health.ValorBase;
    }
}
