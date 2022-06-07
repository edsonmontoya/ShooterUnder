using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EstadosdeCombate 
{
    MOSTRANDO_MARCADOR, 
    LANZAR_HABILIDAD, 
    VERIFICAR_MUERTE,
    SIGUIENTE
}

public class Boss : MonoBehaviour
{
    public GameObject marcador;
    public GameObject bomba;
    public GameObject jefaso;
    public GameObject jugador;

    public Slider barraVidaBoss;

    public AudioSource Scream;

    public bool isALive;
    public bool Atrapado;

    public float SaludBoss;
    public float vidaActualBoss;

    public int damageBoss;

    public EstadosdeCombate estadosdeCombate;

    UnityEngine.AI.NavMeshAgent jefe;

    public MovimientoPersonaje movimientoPersonaje;
    public Stats stats;
    public EnemyController enemy;

    public Transform marca;

    void Start()
    {
        jugador.GetComponent<Stats>();
        this.jefe = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    
    void Update()
    {
        SetSaludBoss(SaludBoss, vidaActualBoss);

        if (!Atrapado)
        {
            this.jefe.destination = enemy.player.position;
        }
        if (Atrapado)
        {
            this.jefe.destination = this.transform.position;
        }

        if (vidaActualBoss <= 0)
        {
            isALive = false;
            Destroy(gameObject);
            Scream.Play();
            enemy.devilVida = false;
        }
    }

    public void SetSaludBoss(float SaludBoss, float vidaActualBoss)
    {
        float porcentaje = vidaActualBoss / SaludBoss;
        this.barraVidaBoss.value = porcentaje;

    }

    public void InstanciandoBoss()
    {
        Vector3 pos = new Vector3(23, 0, Random.Range(20, -23));
        Instantiate(jefaso, pos, Quaternion.identity);
        this.estadosdeCombate = EstadosdeCombate.SIGUIENTE;
        isALive = true;
        StartCoroutine(BossABL());
    }

    public void InstanciandoMarcador()
    {
        marcador.transform.position = new Vector3(movimientoPersonaje.player.position.x, movimientoPersonaje.player.position.y - 1, movimientoPersonaje.player.position.z);
        GameObject marca =  Instantiate(marcador, marcador.transform.position, Quaternion.identity) as GameObject;
        Destroy(marca, 3f);
    }

    public void InstanciandoBomba()
    {
        bomba.transform.position = new Vector3(marca.position.x + 2, marca.position.y + 15, marca.position.z);
        GameObject bomb = Instantiate(bomba, bomba.transform.position, Quaternion.Euler(180, 0, 0)) as GameObject;
        Destroy(bomb, 4f);
    }

    IEnumerator BossABL()
    {
        while(isALive == true)
        {
            switch(this.estadosdeCombate)
            {
                case EstadosdeCombate.MOSTRANDO_MARCADOR:
                    yield return null;
                    InstanciandoMarcador();
                    estadosdeCombate = EstadosdeCombate.LANZAR_HABILIDAD;
                    break;
                case EstadosdeCombate.LANZAR_HABILIDAD:
                    yield return new WaitForSeconds(2f);
                    InstanciandoBomba();
                    estadosdeCombate = EstadosdeCombate.VERIFICAR_MUERTE;
                    break;
                case EstadosdeCombate.VERIFICAR_MUERTE:
                    yield return new WaitForSeconds(1f);
                    if (enemy.preparandoRonda == true)
                    {
                        isALive = false;
                    }

                    estadosdeCombate = EstadosdeCombate.SIGUIENTE;
                    
                    yield return null;
                    break;
                case EstadosdeCombate.SIGUIENTE:
                    yield return new WaitForSeconds(1f);
                    estadosdeCombate = EstadosdeCombate.MOSTRANDO_MARCADOR;
                    break;
            }
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Bala"))
        {
            this.vidaActualBoss = this.vidaActualBoss - stats.Damage._Valor;

        }
    }
}
