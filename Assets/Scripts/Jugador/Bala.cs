using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public Rigidbody bala;
    public Transform arma;

    public float velDisparo;
    public float tiempoDisparo;
    private float inicioDisparar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisparandoBalaNormal()
    {
        if(Time.time > inicioDisparar)
        {
            inicioDisparar = Time.time + tiempoDisparo;
            Rigidbody balaPrefab;

            balaPrefab = Instantiate(bala, arma.position, Quaternion.identity);
            balaPrefab.AddForce(arma.forward * 100 * velDisparo);
        }
        
        
      
    }
   

}
