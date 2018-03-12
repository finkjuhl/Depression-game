using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public bool fireRateBool = true;
    public float velocity = 16;

    private float timer;
    private float fireRate = 0.3f;

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
    }

    //I HATE THIS!! You need to really know why you want to use an IEnumerator before you actually use one
    //and IEnumerator is the most poorly named interface for thread processing that I have ever seen
    void Fire()
    {           
        var bullet = (GameObject)Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * velocity;

        Destroy(bullet, 3.0f);
    }
}