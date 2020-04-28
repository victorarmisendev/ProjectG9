using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSelection : MonoBehaviour
{

    Gamepad[] pads;
    int numberOfPlayers = 2;
    //Activar sets de escoger personaje: 
    public GameObject SelectorPrefab;
    public Transform[] positions;

    void Start()
    {
        //conseguir players. NUM de jugadores. 
        pads = Gamepad.all.ToArray();

        numberOfPlayers = pads.Length;

        for (int i = 0; i < numberOfPlayers; i++)
        {
            //Instance the Selectors: 
            GameObject selector = Instantiate(SelectorPrefab, positions[i].position, Quaternion.identity);
            selector.GetComponent<Selector>().currentPad = pads[i];
        }

    }

    

}
