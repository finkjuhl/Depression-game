using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectController : MonoBehaviour
{
    public GameObject buttonText;
    public GameObject Phone;

    private float timer;

    public float waitTime = 3.0f;

    private bool timerActive = false;

    bool buttonCollide = false;
    bool buttonPressed = false;

    private void Start()
    {
        timer = Time.time;
    }

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

            timerActive = true;         
        }

        if (timerActive)
        {
            timer += 1 * Time.deltaTime;

            if (timer > waitTime)
            {
                SceneManager.LoadScene(2);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        buttonCollide = false;
        buttonText.GetComponent<Text>().text = "";
    }
}