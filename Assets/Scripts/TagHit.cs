using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagHit : MonoBehaviour
{
    //private ParticleSystem particle;

	//Use this for initialization
	void Awake ()
    {
        //particle = GetComponent<ParticleSystem>();
    }
	
	//Update is called once per frame
	void OnCollisionEnter(Collision collision)
    {
		if(collision.gameObject.tag == "Enimy")
        {
            //particle.Play();
            Destroy(gameObject);
        }
	}
}