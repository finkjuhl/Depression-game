using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWasp : MonoBehaviour
{
    public const int maxHealth = 100;
    public int health = maxHealth;

    Animation anim;

    //BAD NAMES!! Name them something you will remember, 
    //and something that a new team member might understand
    public GameObject size;
    public Transform position;

    private void Start()
    {
        anim = GetComponent<Animation>();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
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

                Destroy(gameObject);
            }
        }

        if (collision.gameObject.tag == "Player")
        {
            anim.Play("Sting");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        anim.Play("Flying");
    }
}
