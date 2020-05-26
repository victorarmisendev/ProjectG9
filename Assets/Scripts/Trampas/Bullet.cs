﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    public float dmg;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 7);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 7.0f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerControler>() != null)
        {

            //collision.gameObject.GetComponent<Movement>().DMG(dmg);
        }
        Destroy(gameObject);
    }
}