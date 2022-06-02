using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public Rigidbody bala;
    public Transform arma;
    public AudioSource sonidoBala;
    public Transform mira;
    public float velDisparo;
    public float tiempoDisparo;
    private float inicioDisparar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   //Opcion de prueba del disparo
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DisparandoBalaNormal();
        }
    }
    public void DisparandoBalaNormal()
    {
        if(Time.time > inicioDisparar)
        {
            sonidoBala.Play();
            inicioDisparar = Time.time + tiempoDisparo;
            Rigidbody balaPrefab;

            balaPrefab = Instantiate(bala, arma.position, Quaternion.identity);
            balaPrefab.AddForce(mira.forward * 100 * velDisparo);
        }
    }
}
