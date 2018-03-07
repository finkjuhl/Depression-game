using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public const int maxHealth = 10;
    public int health = maxHealth;

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            health = 0;
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        //BAD NAME! "Enemy" is correct ;)
        if (collision.gameObject.tag == "Enimy")
        {
            health -= 10;

            Debug.Log("rij"); //?? 

            if (health == 0)
            {
                //fucking death
            }
        }
    }
}
