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
        anim.SetFloat("forward", Mathf.Sin(Time.time));
        anim.SetFloat("forward", Mathf.Cos(Time.time));
    }
}