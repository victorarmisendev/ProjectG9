using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject rockFly;
    public GameObject rockFloor;
    public GameObject player;
    private Vector3 playerPos;

    public int attackCD = 4;

    private int boulderCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerArena");
        playerPos = player.transform.position;
        //InvokeRepeating("attack", attackCD, attackCD);
        attack();
    }

    void attack()
    {
        playerPos = player.transform.position;
        int i = Random.Range(1, 2);
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

    }
    void rockRollAttack()
    {
        boulderCount++;
        float xPos = Random.Range(-22.0f, 23.75f);
        Instantiate(rockFloor, new Vector3 (xPos, 15, 12.5f), new Quaternion(0, 0, 0, 1));

    }
}
