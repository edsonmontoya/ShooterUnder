using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public enum RondaStatus
{
    PREPARANDO_ENEMIGOS,
    PREPARANDO_RONDA,
        RONDA_INICIADA
}
public class EnemyController : MonoBehaviour
{
    public GameObject Zombieg;
    public GameObject Ghostg;
    
    private RondaStatus rondastatus;
    public Transform player;
    public Enemigos enemigos;
    public int numeroEnemigosZombie;
    public int numeroInvocacionZombie;
    public int numeroInvocacionGhost;
    public int numeroEnemigosGhost;
    public int spacing = 2;
    public int cantidadRonda;
    public float timer = 10f;
    public Text temporizador;
    public Text numeroRonda;
    
    public int numeroRondas;

    public GestionOpciones opciones;
    public ScriptableEnemigo Ghost;
    public ScriptableEnemigo Zombie;

    public bool preparandoRonda = true;
    // Start is called before the first frame update
    void Start()
    {

        

    }
    

    // Update is called once per frame
    void Update()
    {
        
            //StartCoroutine(RondaLoop());
        
        
        numeroRonda.text = "Ronda" + " "+ numeroRondas.ToString();
        temporizador.text = timer.ToString();
        //Indicamos que si el numero de zombies vivos en este caso el valor es -1 inicie el conteo para iniciar nueva ronda
        if (numeroEnemigosZombie == -1)
        {
            
            timer = timer - 1*Time.deltaTime;
            //Si el tiempo termino instancia los enemigos 
            if(numeroEnemigosZombie == -1 && timer <= 0)
            {
                numeroRondas = numeroRondas + 1;
                Zombie.MonedasDa = Zombie.MonedasDa + 1;
                numeroEnemigosZombie = numeroInvocacionZombie;
                numeroInvocacionZombie = numeroInvocacionZombie + 1;
                InstanciandoEnemigosZombie();
                timer = 10f;
                enemigos.AumentandoVelocidad();
                enemigos.AumentandoCaracteristicasEnemigo();
            }
            

        }
        
        

    }
    /*IEnumerator RondaLoop()
    {
        while (this.preparandoRonda)
        {


            switch (this.rondastatus)
            {
                case RondaStatus.PREPARANDO_ENEMIGOS:
                    if (numeroEnemigosZombie == -1)
                    {
                        enemigos.AumentandoCaracteristicasEnemigo();

                        yield return new WaitForSeconds(0.1f);
                        this.rondastatus = RondaStatus.PREPARANDO_RONDA;
                    }
                    yield return null;

                    break;
                case RondaStatus.PREPARANDO_RONDA:

                    if (numeroEnemigosZombie == -1)
                    {
                        timer = timer - 1 * Time.deltaTime;
                        yield return new WaitForSeconds(10f);
                        this.rondastatus = RondaStatus.RONDA_INICIADA;
                    }
                    yield return null;

                    break;
                case RondaStatus.RONDA_INICIADA:

                    if (numeroEnemigosZombie == -1 && timer <= 0)
                    {
                        numeroRondas = numeroRondas + 1;
                        Zombie.MonedasDa = Zombie.MonedasDa + 1;
                        numeroEnemigosZombie = numeroInvocacionZombie;
                        numeroInvocacionZombie = numeroInvocacionZombie + 1;
                        InstanciandoEnemigosZombie();
                        timer = 10f;
                        
                    }
                        yield return null;

                    break;
            }
        }
    }*/
    
    public void InstanciandoEnemigosZombie()
    {
        for (int y = 0; y < numeroInvocacionZombie; y++)
        {
            Vector3 pos = new Vector3(23, 0, Random.Range(20, -23));
            Instantiate(Zombieg, pos, Quaternion.identity);

        }
    }

}
