using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagHit : MonoBehaviour
{
    //private ParticleSystem particle;

	void Awake ()
    {
        //particle = GetComponent<ParticleSystem>();
    }
	
	void OnCollisionEnter(Collision collision)
    {
		if(collision.gameObject.tag == "Enemy")
        {
            //particle.Play();
            Destroy(gameObject);
        }
	}
}