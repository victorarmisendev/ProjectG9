using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class canvasManager : MonoBehaviour
{
    public int counter = 0;
    public Gamepad[] pads;
    public GameObject canvas1;
    public GameObject canvas2;
    public GameObject canvas3;
    public GameObject canvas4;
    public GameObject canvas5;
    public GameObject canvas6;
    public GameObject canvas7;
    public GameObject canvas8;


    public void CanvasChange()
    {
        counter++;
        switch(counter)
        {
            case 1:
                canvas1.SetActive(false);
                canvas2.SetActive(true);
                break;
            case 2:
                canvas2.SetActive(false);
                canvas3.SetActive(true);
                break;
            case 3:
                canvas3.SetActive(false);
                canvas4.SetActive(true);
                break;
            case 4:
                canvas4.SetActive(false);
                canvas5.SetActive(true);
                break;
            case 5:
                canvas5.SetActive(false);
                canvas6.SetActive(true);
                break;
            case 6:
                canvas6.SetActive(false);
                canvas7.SetActive(true);
                break;
            case 7:
                break;
            default:
                break;

        }
    }


    // Start is called before the first frame update
    void Start()
    {
        pads = Gamepad.all.ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (pads[0].aButton.isPressed && canvas8.active)
        {
            SceneManager.LoadScene("MenuPrincipal");
        }
    }
}
