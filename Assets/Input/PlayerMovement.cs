using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Header("Camera")]
    public Camera mainCamera;
    [Header("Movement")]
    public Rigidbody playerRigidbody;
    public float speed = 4.5f;
    private Vector3 inputDirection;
    private Vector3 movement;
    // InputActions
    PlayerInputActions inputAction;
    // Move
    Vector2 movementInput;



    ////Rotation

    //private Plane playerMovementPlane;

    //private RaycastHit floorRaycastHit;

    //private Vector3 playerToMouse;


    //[Header("Animation")]
    //public Animator playerAnimator;




    void Awake() {
        CreatePlayerMovementPlane();
        inputAction = new PlayerInputActions();
        inputAction.PlayerControls.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        //inputAction.PlayerControls.FireDirection.performed += ctx => lookPosition = ctx.ReadValue<Vector2>();
    }

    void CreatePlayerMovementPlane() {
        //playerMovementPlane = new Plane(transform.up, transform.position + transform.up);
    }

    void FixedUpdate() {

        //Old InputSystem Input
        float h = movementInput.x;
        float v = movementInput.y;
        Vector2 axis = new Vector2(h, v);
        Debug.Log(axis);
        //RB.MovePosition(RB.position + Mov * moveSpeed * Time.fixedDeltaTime); // Movimiento en XY.   
    }

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }
}
