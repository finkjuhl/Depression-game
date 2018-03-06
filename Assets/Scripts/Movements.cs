using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movements : MonoBehaviour
{
    Animator anim;
    NavMeshAgent nav;
    public GameObject player;

    //bool animateCombat = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<NavMeshAgent>().enabled = true;
            player = GameObject.FindGameObjectWithTag("Player");
            anim.SetFloat("left", Mathf.Sin(Time.time));
            Debug.Log("enter");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        nav.destination = player.transform.position;
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
