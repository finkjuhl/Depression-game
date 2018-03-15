using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;


public class Health : MonoBehaviour
{
    public const float maxHealth = 100;
    public float health = 100;

    public GameObject playerCamera;
    public GameObject sliderUI;

    public bool healthDamage = true;
    public bool healthHeal = false;

    public float attackWait = 2.0f;
    public float healthWait = 9.0f;
    public float meleeDmg = 10.0f;
    public float healthAmount = 10.0f;

    private float timer;
    private float waitTime;

    private float HPTimer;
    private float HPWait;

    private void Start()
    {
        HPTimer = Time.time;
        timer = Time.time;
        health = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        if (healthDamage)
        {
            health -= amount;

            if (health < 0)
            {
                health = 0;
            }

            healthDamage = false;
        }   
    }

    private void Update()
    {
        sliderUI.GetComponent<Slider>().value = health;

        if (Time.time - timer > waitTime)
        {
            timer = Time.time;
            waitTime = attackWait;

            healthDamage = true;
        }

        if (Time.time - HPTimer > HPWait)
        {
            HPTimer = Time.time;
            HPWait = healthWait;

            healthHeal = true;

            if (health < maxHealth)
            {
                health += healthAmount;
                CameraChange();
            }
        }
    }

    void CameraChange()
    {
        playerCamera.GetComponent<VignetteAndChromaticAberration>().chromaticAberration = ((maxHealth - health) / 100) * 45;
        playerCamera.GetComponent<VignetteAndChromaticAberration>().intensity = ((maxHealth - health) / 100.0f) * 0.7f;
        playerCamera.GetComponent<VignetteAndChromaticAberration>().blur = ((maxHealth - health) / 100.0f) * 0.5f;

        playerCamera.GetComponent<Fisheye>().strengthX = ((maxHealth - health) / 100.0f) * 0.5f;
        playerCamera.GetComponent<Fisheye>().strengthY = ((maxHealth - health) / 100.0f) * 0.5f;
    }

    void OnCollisionEnter(Collision collision)
    {
        //BAD NAME! "Enemy" is correct ;)
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(meleeDmg);

            CameraChange();

            if (health == 0)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}