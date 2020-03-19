using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Rigidbody RB;
    Vector3 Mov;
 

    // Start is called before the first frame update
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Mov.x=Input.GetAxisRaw("Horizontal");
        Mov.z = Input.GetAxisRaw("Vertical");

    }
    private void FixedUpdate()
    {

        RB.MovePosition(RB.position + Mov * moveSpeed * Time.fixedDeltaTime);

    }
}
