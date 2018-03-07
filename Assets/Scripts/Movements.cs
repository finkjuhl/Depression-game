using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movements : MonoBehaviour
{
    Animator anim;
    NavMeshAgent nav;
    public GameObject player;
    public float distanceOffset = 5.0f;

    //bool animateCombat = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        if (gameObject.transform.position.x - player.transform.position.x < distanceOffset
            && gameObject.transform.position.z - player.transform.position.z < distanceOffset)
        {
            GetComponent<NavMeshAgent>().enabled = true;
            // player = GameObject.FindGameObjectWithTag("Player");
            anim.SetFloat("left", Mathf.Sin(Time.time));
            nav.destination = player.transform.position;
           // Debug.Log("Following");
        }
    }

   /* void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<NavMeshAgent>().enabled = true;
           // player = GameObject.FindGameObjectWithTag("Player");
            anim.SetFloat("left", Mathf.Sin(Time.time));
            Debug.Log(other.tag);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (gameObject.GetComponent<NavMeshAgent>().enabled == true)
        {
            nav.destination = player.transform.position;
            Debug.Log("Staying");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        Debug.Log("exit");
    }

    /*void OnTriggerEnter(Collider other)           //make this it's own perhaps
    {
        if(other.tag == "Player")
        {
            animateCombat = true;
            anim.SetFloat("forward", 0.5f);
        }
    }*/
}
