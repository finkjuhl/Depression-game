using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.ImageEffects;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public const float maxHealth = 100;
    public float health = 100;

    public GameObject playerCamera;
    public GameObject sliderUI;

    public bool healthDamage = true;

    public float timer;
    public float waitTime;

    private void Start()
    {
        timer = Time.time;
        health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if (healthDamage)
        {
            health -= amount;

            //access the slider
            sliderUI.GetComponent<Slider>().value = health;

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
            playerCamera.GetComponent<VignetteAndChromaticAberration>().chromaticAberration = ((maxHealth - health) / 100)*45;
            playerCamera.GetComponent<VignetteAndChromaticAberration>().intensity = ((maxHealth - health) / 100.0f) * 0.6f;
            playerCamera.GetComponent<VignetteAndChromaticAberration>().blur = ((maxHealth - health) / 100.0f) * 0.5f;

            playerCamera.GetComponent<Fisheye>().strengthX = ((maxHealth - health) / 100.0f) * 0.5f;
            playerCamera.GetComponent<Fisheye>().strengthY = ((maxHealth - health) / 100.0f) * 0.5f;

            if (health == 0)
            {
                //death
            }
        }
    }
}