using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public bool fireRateBool = true;
    public float fireRate = 0.3f;
    public float velocity = 16;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StartCoroutine(Fire());
        }
    }

    //I HATE THIS!! You need to really know why you want to use an IEnumerator before you actually use one
    //and IEnumerator is the most poorly named interface for thread processing that I have ever seen
    IEnumerator Fire()
    {
        
        if (fireRateBool == true)
        {
            fireRateBool = false;
        var bullet = (GameObject)Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * velocity;

        Destroy(bullet, 3.0f);
          yield return new WaitForSeconds(fireRate);
            fireRateBool = true;
        }
    }
}