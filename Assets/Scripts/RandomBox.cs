using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBox : MonoBehaviour
{
    public enum Type { WEAPON , TRAP};
    public Type mytipe;

    public GameObject[] possibleTrap;
    public GameObject[] possibleWeapon;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //
            if (mytipe == Type.TRAP)
            {
                int randnum = Random.Range(0, 0);
                other.GetComponent<PlayerControler>().currentTrap = possibleTrap[randnum];
            }
            else if (mytipe == Type.WEAPON)
            {
                int randnum = Random.Range(0, 1);

                other.GetComponent<PlayerControler>().currentWeapon = possibleWeapon[randnum];
            }
        }
    }
}
