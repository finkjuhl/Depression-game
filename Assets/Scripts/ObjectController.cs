using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectController : MonoBehaviour
{
    public GameObject buttonText;
    public GameObject Phone;

    bool buttonCollide = false;
    bool buttonPressed = false;

    void OnTriggerEnter(Collider other)
    {
        buttonCollide = true;
        buttonText.GetComponent<Text>().text = "Press E";
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyUp("e"))
        {
            buttonPressed = true;
            Phone.GetComponent<AudioSource>().Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        buttonCollide = false;
        buttonText.GetComponent<Text>().text = "";
    }
}