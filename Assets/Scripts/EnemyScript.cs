using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public const int maxHealth = 10;
    public int health = maxHealth;
    public GameObject en;
    public Transform eni;

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
        if (collision.gameObject.tag == "Pill")
        {
            health -= 10;

            if (health == 0)
            {
                Instantiate(en, eni.position, eni.rotation);
                Instantiate(en, eni.position, eni.rotation);
                Instantiate(en, eni.position, eni.rotation);
                Instantiate(en, eni.position, eni.rotation);
                Instantiate(en, eni.position, eni.rotation);
                Instantiate(en, eni.position, eni.rotation);

                Destroy(gameObject);
            }
        }
    }
}
