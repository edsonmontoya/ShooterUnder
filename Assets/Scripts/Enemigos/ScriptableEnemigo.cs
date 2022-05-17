
using UnityEngine;
[CreateAssetMenu]
public class ScriptableEnemigo : ScriptableObject
{
    public int IdEnemy;
    public GameObject Enemigo;
    public string nameEnemigo;
    public int Damage;

    public EnemyController enemyController;
    public int MonedasDa;


}
