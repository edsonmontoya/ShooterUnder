using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vendedor : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent Ally;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        Ally = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Ally.destination = player.position;
    }
}
