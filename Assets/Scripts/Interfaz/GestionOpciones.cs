using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionOpciones : MonoBehaviour
{
    public ScriptableEnemigo enemigoda;
    public Text Almas;
    public Enemigos enemigo;
    public float cantidadAlmas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActualizandoAlmas()
    {
      Almas.text = cantidadAlmas.ToString();
    }
}
