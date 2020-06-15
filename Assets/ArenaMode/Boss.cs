using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject rockFly;
    public GameObject rockFloor;
    public GameObject player;
    private Vector3 playerPos;

    public float attackCD = 5.0f;
    int counterAttacks = 0;

    private int attackCounter;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerArena");
        playerPos = player.transform.position;
        InvokeRepeating("attack", 4, 4);
        
    }

    void attack()
    {
        counterAttacks++;
        playerPos = player.transform.position;
        int i = Random.Range(0, 2);
        switch(i)
        {
            case 0:
                rockFlyAttack();
                break;
            case 1:
                rockRollAttack();
                break;
            case 2:
                spawnMinion();
                break;
            default:
                break;
        }
    }

    void rockFlyAttack()
    {
        Instantiate(rockFly, playerPos, new Quaternion(0, 0, 0, 1)); ;
    }
    void spawnMinion()
    {
        float xPos = Random.Range(-22.0f, 23.75f);
        float zPos = Random.Range(-22.0f, 23.75f);

    }
    void rockRollAttack()
    {
        float xPos = Random.Range(-22.0f, -7.0f);
        Instantiate(rockFloor, new Vector3 (xPos, 15, 12.5f), new Quaternion(0, 0, 0, 1));
        xPos = Random.Range(-8.0f, 7.0f);
        Instantiate(rockFloor, new Vector3(xPos, 15, 12.5f), new Quaternion(0, 0, 0, 1));
        xPos = Random.Range(8.0f, 23.75f);
        Instantiate(rockFloor, new Vector3(xPos, 15, 12.5f), new Quaternion(0, 0, 0, 1));

    }
    //private void Update()
    //{
    //    if (counterAttacks >= 10)
    //    {
    //        counterAttacks = 0;
    //        if(attackCD > 3)
    //        {
    //            attackCD--;
    //        }
    //    }
    //}
}
