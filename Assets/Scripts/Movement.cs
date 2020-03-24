using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    //[Header("Camera")]
    //public Camera mainCamera;
    //public float moveSpeed = 5.0f;
    //public Rigidbody RB;
    //Vector3 Mov;

    //[Header("Movement")]
    //private Vector2 m_Move;

    //private Vector3 inputDirection;
    //private Vector3 movement;
    //PlayerInputActions actions;
    //// Move
    //Vector2 movementInput;
    //public void OnMove(InputValue value)
    //{
    //    m_Move = value.Get<Vector2>();
    //}

    //void Awake()
    //{
    //    actions = new PlayerInputActions();
    //    actions.PlayerControls.Move.performed += ctx =>
    //    movementInput = ctx.ReadValue<Vector2>();
    //    //actions.PlayerControls.FireDirection.performed += ctx => lookPosition = ctx.ReadValue<Vector2>();
    //}

    //void Start()
    //{
        
    //    RB = gameObject.GetComponent<Rigidbody>();
    //}

    //void Update()
    //{
    //    //Mov.x = Input.GetAxisRaw("Horizontal");
    //    //Mov.z = Input.GetAxisRaw("Vertical");

    //    //if (m_PlayerInput == null)
    //    //{
    //    //    m_PlayerInput = GetComponent<PlayerInput>();
    //    //    m_PlayerInput = GetComponent<PlayerInput>();
    //    //    m_MoveAction = m_PlayerInput.actions["Move"];
    //    //    Debug.Log("Input exists");
    //    //}
    //    //else
    //    //{
    //    //    Debug.Log("Input doesnt exists");
    //    //}

    //    //var move = m_MoveAction.ReadValue<Vector2>();

    //    //Debug.Log(move);
    //    //print(movement.actionMap.actions[0].name);
   
    //}

    //private void FixedUpdate()
    //{
    //    float h = movementInput.x;
    //    float v = movementInput.y;
    //    //if(inputMap.GetA)

    //    //var gamepad = Gamepad.current;
    //    //if (gamepad == null)
    //    //    return;

    //    ////Acelerar con el de RT. 
    //    //if (gamepad.rightTrigger.isPressed)
    //    //{
    //    //    RB.MovePosition(RB.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
    //    //}

    //    //Vector2 gp = gamepad.leftStick.ReadValue();

    //    //if(gp.x > 0.0f)
    //    //{
    //    //    RB.MoveRotation(RB.rotation * Quaternion.Euler(0.0f , 100.0f * Time.fixedDeltaTime, 0.0f));
    //    //}
    //    //if (gp.x < 0.0f)
    //    //{
    //    //    RB.MoveRotation(RB.rotation * Quaternion.Euler(0.0f, -100.0f * Time.fixedDeltaTime, 0.0f));
    //    //}

    //    //RB.MovePosition(RB.position + Mov * moveSpeed * Time.fixedDeltaTime); // Movimiento en XY.       

    //}
    //public void Stun(int segundos)
    //{

    //}
    //public void DMG (float dmg)
    //{

    //}
}
