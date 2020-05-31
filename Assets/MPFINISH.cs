using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MPFINISH : MonoBehaviour
{
    public Text points;
    public Text GG;
    public MPPlayerRail player;
    public Gamepad[] pads;

    private void Awake()
    {
        pads = Gamepad.all.ToArray();
    }
    // Update is called once per frame
    void Update()
    {
        points.text = "Points: " + player.points.ToString();
        switch (player.playerNum)
        {
            case 1:
                GG.color = Color.blue;
                break;
            case 2:
                GG.color = Color.red;
                break;
            case 3:
                GG.color = Color.green;
                break;
            case 4:
                GG.color = Color.yellow;
                break;
        }
        if(pads[0].startButton.isPressed)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }

}
