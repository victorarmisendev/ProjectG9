using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{

    private float speedTimer = 3;

    public Text countdown;

    private IEnumerator coroutine;
    public AudioSource clip;

    // Start is called before the first frame update
    void Start()
    {
       coroutine = ExecuteAfterTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (speedTimer > 0)
        {
            speedTimer -= Time.deltaTime;
            if (speedTimer >= 2)
            { 
                countdown.text = "3";
            }
            else if (speedTimer >= 1)
            {
                countdown.text = "2";
            }
            else if (speedTimer > 0)
            {
                countdown.text = "1";
            }
        }

        else
        {
            countdown.text = "GO!";
            //
            StartCoroutine(coroutine);
        }
    }

    IEnumerator ExecuteAfterTime()
    {
        
        yield return new WaitForSeconds(2);
        clip.Play();
        Destroy(countdown.gameObject);
        // Code to execute after the delay
    }
}
