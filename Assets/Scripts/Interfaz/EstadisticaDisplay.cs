using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EstadisticaDisplay : MonoBehaviour
{
    public Text nametext;
    public Text valorText;
    public Text costeText;

    private void OnValidate()
    {
        Text[] texts = GetComponentsInChildren<Text>();
        nametext = texts[0];
        valorText = texts[1];
        costeText = texts[2];
    }
}
