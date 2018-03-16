using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour
{
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

	void Update ()
    {
        anim.SetFloat("Idle", Mathf.Sin(Time.time));
    }
}