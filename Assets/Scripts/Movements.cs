using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movements : MonoBehaviour
{
    Animator anim;
    NavMeshAgent nav;
    GameObject player;
    public float distanceOffset = 5.0f;

    //bool animateCombat = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    //fixed update is normally used only when physics is involved
    private void FixedUpdate()
    {
        //this is cleaner:
        if (Vector3.Distance(transform.position, player.transform.position) < distanceOffset)
        {
            GetComponent<NavMeshAgent>().enabled = true;
            
            anim.SetFloat("left", Mathf.Sin(Time.time));
            nav.destination = player.transform.position;
        }
    }
}
