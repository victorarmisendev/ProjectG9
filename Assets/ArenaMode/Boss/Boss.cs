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

    public Animator BossAnimator;

    public AudioSource attack1Audio;
    public AudioSource attack2Audio;

    private int attackCounter;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerArena");
        playerPos = player.transform.position;
        InvokeRepeating("attack", 4, 4);
        BossAnimator = gameObject.GetComponent<Animator>();
        
    }

    void attack()
    {
        counterAttacks++;
        playerPos = player.transform.position;
        int i = Random.Range(0, 2);
        switch(i)
        {
            case 0:
                //rockFlyAttack();
                BossAnimator.SetTrigger("RockAttack1");
                Invoke("rockFlyAttack",2.0f);
                Invoke("attack1Play", 1.0f);
                break;
            case 1:
                //rockRollAttack();
                BossAnimator.SetTrigger("RockAttack2");
                Invoke("rockRollAttack", 2.0f);
                Invoke("attack2Play", 1.0f);
                break;
            case 2:
                spawnMinion();
                break;
            default:
                break;
        }
    }
    void attack1Play()
    {
        attack1Audio.Play();
    }
    void attack2Play()
    {
        attack2Audio.Play();
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
        Instantiate(rockFloor, new Vector3 (xPos, 25, 12.5f), new Quaternion(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1));
        xPos = Random.Range(-8.0f, 7.0f);
        Instantiate(rockFloor, new Vector3(xPos, 25, 12.5f), new Quaternion(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1));
        xPos = Random.Range(8.0f, 23.75f);
        Instantiate(rockFloor, new Vector3(xPos, 25, 12.5f), new Quaternion(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1));

    }

}
