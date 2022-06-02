using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            Destroy(this.gameObject);
        }
    }

}
