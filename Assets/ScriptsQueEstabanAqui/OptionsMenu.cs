using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class OptionsMenu : MonoBehaviour
{
    public AudioSource AS;
    public Dropdown resolutioDropdown;
    public Text[] text_modes;
    private bool detect = false;
    public static int state = 0;
    public Gamepad[] pad;
    public GameObject CanvasReturn;
    private bool pressedOnce = false;
    public ScrollRect resOptions;

    //resolution
    bool inResolution = false;
    static int resState = 0;
    public Text[] res_texts;
    //full screen
    bool isFullScreen = true;
    public Toggle FullScreen;
    //Graphics
    public Text[] graph_texts;
    static int graphState = 0;
    bool inGraphics = false;
    //VOLUME
    bool inVolume = false;
    float volum;
    public Slider Volum;
    private void Start()
    {
        pad = Gamepad.all.ToArray();

        resolutioDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currResindex = 0;
        SetResolution(1920,1080);
        resolutioDropdown.AddOptions(options);
        resolutioDropdown.value = currResindex;
        resolutioDropdown.RefreshShownValue();
    }
    public void Update()
    {
        if (inResolution)
        {
            if (pad[0].leftStick.left.isPressed && detect == false)
            {
                resState--;
                detect = true;
                if (resState < 0)
                {
                    resState = 0;
                }
            }
            else if (pad[0].leftStick.right.isPressed&& detect == false)
            {
                detect = true;
                resState++;
                if (resState > 3)
                {
                    resState = 3;
                }
            }
            if (pad[0].leftStick.ReadValue().y == 0.0f)
            {
                detect = false;
                Debug.Log("Released");
            }
            if (pad[0].aButton.isPressed && resState == 0 && pressedOnce == false)
            {
                SetResolution(1920, 1080);
                inResolution = false;
                pressedOnce = true;
            }
            if (pad[0].aButton.isPressed && resState == 1 && pressedOnce == false)
            {
                SetResolution(1280, 1024);
                inResolution = false;
                pressedOnce = true;
            }
            if (pad[0].aButton.isPressed && resState == 2 && pressedOnce == false)
            {
                SetResolution(1280, 720);
                inResolution = false;
                pressedOnce = true;

            }
            if (pad[0].aButton.isPressed && resState == 3 && pressedOnce == false)
            {
                SetResolution(800, 640);
                inResolution = false;
                pressedOnce = true;

            }
            if (pad[0].bButton.isPressed && pressedOnce == false)
            {
                inResolution = false;
            }
        }
        else if(inVolume)
        {
            if (pad[0].leftStick.left.isPressed && detect == false)
            {
                Volum.value=Volum.value-0.1f;
                detect = true;
                if (Volum.value < 0)
                {
                    Volum.value = 0;
                }
                SetVolum(Volum.value);
            }
            else if (pad[0].leftStick.right.isPressed && detect == false)
            {
                detect = true;
                Volum.value = Volum.value + 0.1f;
                if (graphState > 1)
                {
                    graphState = 1;
                }
                SetVolum(Volum.value);
            }
            if (pad[0].leftStick.ReadValue().y == 0.0f)
            {
                detect = false;
                Debug.Log("Released");
            }
            if (pad[0].bButton.isPressed && pressedOnce == false)
            {
                inVolume = false;
            }
            Debug.Log("inVolume");
        }
       else if (inGraphics)
        {
            if (pad[0].leftStick.left.isPressed && detect == false)
            {
                graphState--;
                detect = true;
                if (graphState < 0)
                {
                    graphState = 0;
                }
            }
            else if (pad[0].leftStick.right.isPressed && detect == false)
            {
                detect = true;
                graphState++;
                if (graphState > 3)
                {
                    graphState = 3;
                }
            }
            if (pad[0].leftStick.ReadValue().y == 0.0f)
            {
                detect = false;
                Debug.Log("Released");
            }
            if (pad[0].aButton.isPressed && resState == 0 && pressedOnce == false)
            {
                SetQuality(5);
                 inGraphics = false;
                pressedOnce = true;
            }
            if (pad[0].aButton.isPressed && resState == 1 && pressedOnce == false)
            {
                SetQuality(3);
                inGraphics = false;
                pressedOnce = true;
            }
            if (pad[0].aButton.isPressed && resState == 2 && pressedOnce == false)
            {
                SetQuality(2);
                inGraphics = false;
                pressedOnce = true;

            }
            if (pad[0].aButton.isPressed && resState == 3 && pressedOnce == false)
            {
                SetQuality(1);
                 inGraphics = false;
                pressedOnce = true;

            }
            if (pad[0].bButton.isPressed && pressedOnce == false)
            {
                inGraphics = false;
            }
        }
        else
        {
            if (pad[0].leftStick.up.isPressed && detect == false)
            {
                Debug.Log("up");
                detect = true;
                state--;
                if (state < 0)
                {
                    state = 0;
                }
            }
            else if (pad[0].leftStick.down.isPressed && detect == false)
            {
                Debug.Log("down");
                detect = true;
                state++;
                if (state > 4)
                {
                    state = 4;
                }
            }
            if (pad[0].leftStick.ReadValue().y == 0.0f)
            {
                detect = false;
                Debug.Log("Released");
            }
            //Apretar boton
            if (pad[0].aButton.isPressed && state == 0 && pressedOnce == false)
            {
                inResolution = true;
                pressedOnce = true;
            }
            if (pad[0].aButton.isPressed && state == 1 && pressedOnce == false)
            {
                SetFullScreen();
                pressedOnce = true;
            }
            if (pad[0].aButton.isPressed && state == 2 && pressedOnce == false)
            {
                inGraphics = true;
                pressedOnce = true;
            }
            if (pad[0].aButton.isPressed && state == 3 && pressedOnce == false)
            {
                inVolume = true;
                pressedOnce = true;
            }
            if (pad[0].aButton.isPressed && state == 4 && pressedOnce == false)
            {
                CanvasReturn.SetActive(true);
                state = 0;
                gameObject.SetActive(false);
            }
        }
        Colors();
        
        if(pressedOnce == true)
        {
            StartCoroutine(InvulCD());
        }
    }
    IEnumerator InvulCD()
    {
        yield return new WaitForSeconds(0.5f);
        pressedOnce = false;
    }
    public void SetVolum(float volum)
    {
        AS.volume = volum / 10;
    }
    public void SetQuality(int QualityIndex)
    {
        QualitySettings.SetQualityLevel(QualityIndex);
    }
    public void SetFullScreen ()
    {
        if(isFullScreen)
        {
            isFullScreen = false;
            FullScreen.isOn = false;
        }
        else
        {
            isFullScreen = true;
            FullScreen.isOn = true;
        }
        Screen.fullScreen = isFullScreen;
    }
    public void SetResolution(int width, int height)
    {
        Screen.SetResolution(width, height, Screen.fullScreen);
    }
    private void Colors()
    {
        if (state == 0)
        {
            text_modes[0].GetComponent<Text>().color = Color.green;
            if(inResolution)
            {
                text_modes[0].GetComponent<Text>().color = Color.white;
            }
            text_modes[1].GetComponent<Text>().color = Color.grey;
            text_modes[2].GetComponent<Text>().color = Color.grey;
            text_modes[3].GetComponent<Text>().color = Color.grey;
            text_modes[4].GetComponent<Text>().color = Color.grey;
        }
        if (state == 1)
        {
            text_modes[0].GetComponent<Text>().color = Color.grey;
            text_modes[1].GetComponent<Text>().color = Color.green;
            text_modes[2].GetComponent<Text>().color = Color.grey;
            text_modes[3].GetComponent<Text>().color = Color.grey;
            text_modes[4].GetComponent<Text>().color = Color.grey;
        }
        if (state == 2)
        {
            text_modes[0].GetComponent<Text>().color = Color.grey;
            text_modes[1].GetComponent<Text>().color = Color.grey;
            text_modes[2].GetComponent<Text>().color = Color.green;
            text_modes[3].GetComponent<Text>().color = Color.grey;
            text_modes[4].GetComponent<Text>().color = Color.grey;
        }
        if (state == 3)
        {
            text_modes[0].GetComponent<Text>().color = Color.grey;
            text_modes[1].GetComponent<Text>().color = Color.grey;
            text_modes[2].GetComponent<Text>().color = Color.grey;
            text_modes[3].GetComponent<Text>().color = Color.green;
            text_modes[4].GetComponent<Text>().color = Color.grey;
        }
        if (state == 4)
        {
            text_modes[0].GetComponent<Text>().color = Color.grey;
            text_modes[1].GetComponent<Text>().color = Color.grey;
            text_modes[2].GetComponent<Text>().color = Color.grey;
            text_modes[3].GetComponent<Text>().color = Color.grey;
            text_modes[4].GetComponent<Text>().color = Color.green;
        }
        //resolution
        if (resState == 0)
        {
            res_texts[0].GetComponent<Text>().color = Color.white;
            if (inResolution)
            {
                res_texts[0].GetComponent<Text>().color = Color.green;
            }
            res_texts[1].GetComponent<Text>().color = Color.grey;
            res_texts[2].GetComponent<Text>().color = Color.grey;
            res_texts[3].GetComponent<Text>().color = Color.grey;
        }
        if (resState == 1)
        {
            res_texts[0].GetComponent<Text>().color = Color.grey;
            res_texts[1].GetComponent<Text>().color = Color.white;
            if (inResolution)
            {
                res_texts[1].GetComponent<Text>().color = Color.green;
            }
            res_texts[2].GetComponent<Text>().color = Color.grey;
            res_texts[3].GetComponent<Text>().color = Color.grey;

        }
        if (resState == 2)
        {
            res_texts[0].GetComponent<Text>().color = Color.grey;
            res_texts[1].GetComponent<Text>().color = Color.grey;
            res_texts[2].GetComponent<Text>().color = Color.white;
            if (inResolution)
            {
                res_texts[2].GetComponent<Text>().color = Color.green;
            }
            res_texts[3].GetComponent<Text>().color = Color.grey;

        }
        if (resState == 3)
        {
            res_texts[0].GetComponent<Text>().color = Color.grey;
            res_texts[1].GetComponent<Text>().color = Color.grey;
            res_texts[2].GetComponent<Text>().color = Color.grey;
            res_texts[3].GetComponent<Text>().color = Color.white;
            if (inResolution)
            {
                res_texts[3].GetComponent<Text>().color = Color.green;
            }
        }
        //Graphic
        if (graphState == 0)
        {
            graph_texts[0].GetComponent<Text>().color = Color.white;
            if (inGraphics)
            {
                graph_texts[0].GetComponent<Text>().color = Color.green;
            }
            graph_texts[1].GetComponent<Text>().color = Color.grey;
            graph_texts[2].GetComponent<Text>().color = Color.grey;
            graph_texts[3].GetComponent<Text>().color = Color.grey;
        }
        if (graphState == 1)
        {
            graph_texts[0].GetComponent<Text>().color = Color.grey;
            graph_texts[1].GetComponent<Text>().color = Color.white;
            if (inGraphics)
            {
                graph_texts[1].GetComponent<Text>().color = Color.green;
            }
            graph_texts[2].GetComponent<Text>().color = Color.grey;
            graph_texts[3].GetComponent<Text>().color = Color.grey;

        }
        if (graphState == 2)
        {
            graph_texts[0].GetComponent<Text>().color = Color.grey;
            graph_texts[1].GetComponent<Text>().color = Color.grey;
            graph_texts[2].GetComponent<Text>().color = Color.white;
            if (inGraphics)
            {
                graph_texts[2].GetComponent<Text>().color = Color.green;
            }
            graph_texts[3].GetComponent<Text>().color = Color.grey;

        }
        if (graphState == 3)
        {
            graph_texts[0].GetComponent<Text>().color = Color.grey;
            graph_texts[1].GetComponent<Text>().color = Color.grey;
            graph_texts[2].GetComponent<Text>().color = Color.grey;
            graph_texts[3].GetComponent<Text>().color = Color.white;
            if (inGraphics)
            {
                graph_texts[3].GetComponent<Text>().color = Color.green;
            }
        }

    }
}
