using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.ImageEffects;
using UnityEngine;

public class Health : MonoBehaviour
{
    public const int maxHealth = 100;
    public int health = maxHealth;

    public GameObject playerCamera;

    public bool healthDamage = true;

    public float timer;
    public float waitTime;

    private void Start()
    {
        timer = Time.time;
    }

    public void TakeDamage(int amount)
    {
        if (healthDamage)
        {
            health -= amount;

            if (health <= 0)
            {
                health = 0;
            }

            healthDamage = false;
        }
    }

    private void Update()
    {
        if (Time.time - timer > waitTime)
        {
            timer = Time.time;
            waitTime = 2.0f;

            healthDamage = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        //BAD NAME! "Enemy" is correct ;)
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(10);

            playerCamera.GetComponent<VignetteAndChromaticAberration>().chromaticAberration += 0.45f;

            Debug.Log("hit"); //?? 

            if (health == 0)
            {
                //death
            }
        }
    }
}
