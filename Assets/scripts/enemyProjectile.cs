using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectile : MonoBehaviour
{
    private int damageAmount;
    // public min, max;

    // private int damageAmount = 20;

    

    private void OnCollisionEnter(Collision other)
    {
        damageAmount  = Random.Range(5, 25);
        
        if(other.transform.tag == "Player")
        {
            playerController player = other.transform.GetComponent<playerController>();
            player.PlayerTakeDamage(damageAmount);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject, 1f);
        }
    }
}
