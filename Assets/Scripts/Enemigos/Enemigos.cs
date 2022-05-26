using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigos : MonoBehaviour
{
    public ScriptableEnemigo enemigoscr;
    public Text vidaMaximaEnemigo;
    public Slider barraVidaEnemigo;
    public Image barravidaMaxEnemy;
    public Stats statsPersonaje;
    public float SaludEnemigo;
    public float vidaActualEnemigo;
    UnityEngine.AI.NavMeshAgent enemigo;
    public EnemyController enemyController;
    public bool Atrapado = false;
    public Bala bala;
    public GestionOpciones opciones;
    public GameObject jugador;
    public AudioSource zombieDead;

    // Start is called before the first frame update
    void Start()
    {
        jugador.GetComponent<Stats>();
        this.enemigo = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    //Momentaneo
    private void OnMouseDown()
    {
            bala.DisparandoBalaNormal();
    }
    // Update is called once per frame
    void Update()
    {
        //Si el enemigo esta en la posicion del jugador se detendra, de lo contrario te seguira
        if (!Atrapado)
        {
           this.enemigo.destination = enemyController.player.position;
        }
        if (Atrapado)
        {
            this.enemigo.destination = this.transform.position;
        }


        if (vidaActualEnemigo <= 0)
        {   
            enemyController.numeroEnemigosZombie = enemyController.numeroEnemigosZombie - 1;
            opciones.cantidadAlmas = opciones.cantidadAlmas + enemyController.Zombie.MonedasDa;
            opciones.ActualizandoAlmas();
            zombieDead.Play();
            Destroy(gameObject);
        }

        SetSaludEnemigo(SaludEnemigo,vidaActualEnemigo);

        
    }
    
    //Establecemos salud del enemigo
    public void SetSaludEnemigo(float saludMaximaEnemigo, float saludActualEnemigo)
    {
        this.vidaMaximaEnemigo.text = $"{Mathf.RoundToInt(vidaActualEnemigo)}/{Mathf.RoundToInt(SaludEnemigo)}";
        float porcentaje = vidaActualEnemigo / SaludEnemigo;
        this.barraVidaEnemigo.value = porcentaje;

    }
    public void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
           Atrapado = true;
            
        }
        if (collision.CompareTag("Bala"))
        {
            this.vidaActualEnemigo = this.vidaActualEnemigo - statsPersonaje.Damage._Valor;

        }
    }
    

    public void OnTriggerExit(Collider collision)
    {
            if (collision.CompareTag("Player"))
            {
               Atrapado = false;
            }
    }
    public void AumentandoCaracteristicasEnemigo()
    {
        SaludEnemigo = SaludEnemigo * 1.1f;
        vidaActualEnemigo = SaludEnemigo;
    }
    public void AumentandoVelocidad()
    {
        enemigo.speed = enemigo.speed + 1.005f;
    }
    
    public void AumentandoAlMaximo()
    {
        SaludEnemigo = SaludEnemigo * 1.5f;
        vidaActualEnemigo = SaludEnemigo;
    }
    public void AumentandoMaximaVelocidad()
    {
        enemigo.speed = enemigo.speed + 1.1f;
    }

}
