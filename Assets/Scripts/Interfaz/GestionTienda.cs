using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionTienda : MonoBehaviour
{
    public GameObject Caracteristicas;
    //public bool caracteristicasEncendido;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Caracteristicas.SetActive(true);
            //Cursor.lockState = CursorLockMode.None;
        }
    }
    public void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Caracteristicas.SetActive(false);
            //Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
