using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public bool fireRateBool = true;
    public float velocity = 14;

    public int ammo = 0;
    public Text uitext;

    private float timer;
    private float fireRate = 0.2f;

    private void Start()
    {
        timer = Time.time;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && fireRateBool)
        {
            fireRateBool = false;
            Fire();           
        }

        if (Time.time - timer > fireRate)
        {
            fireRateBool = true;
            timer = Time.time;
        }

        if (uitext != null)
        {
            uitext.text = ammo.ToString();
        }
    }

    void Fire()
    {           
        var bullet = (GameObject)Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * velocity;

        ammo += 1;

        Destroy(bullet, 3.0f);
    }
}