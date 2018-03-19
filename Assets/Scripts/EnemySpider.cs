using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpider : MonoBehaviour
{
    public const int maxHealth = 100;
    public int health = maxHealth;

    Animation anim;

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
            anim.Play("Attack");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        anim.Play("Walk");
    }
}