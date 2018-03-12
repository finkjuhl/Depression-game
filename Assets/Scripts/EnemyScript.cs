using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public const int maxHealth = 10;
    public int health = maxHealth;

    //BAD NAMES!! Name them something you will remember, 
    //and something that a new team member might understand
    public GameObject size;
    public Transform position;

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            //health less than zero, dead yes???
            health = 0;
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        //this is where the bullet hits the big npc, and makes little ones?
        
        //you can instantiate, but often it is better to have them simply hidden,
        //but already active. very important in a mobile game with limited resources
        if (collision.gameObject.tag == "Pill")
        {
            health -= 10;

            if (health == 0)
            {
                Instantiate(size, position.position, position.rotation);
                Instantiate(size, position.position, position.rotation);
                Instantiate(size, position.position, position.rotation);
                Instantiate(size, position.position, position.rotation);
                Instantiate(size, position.position, position.rotation);
                Instantiate(size, position.position, position.rotation);

                Destroy(gameObject);
            }
        }
    }
}
