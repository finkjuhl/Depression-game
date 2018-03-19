using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movements : MonoBehaviour
{
    NavMeshAgent nav;
    GameObject player;

    public float distanceOffset = 10.0f;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < distanceOffset)
        {
            GetComponent<NavMeshAgent>().enabled = true;
            
            nav.destination = player.transform.position;
        }
    }
}