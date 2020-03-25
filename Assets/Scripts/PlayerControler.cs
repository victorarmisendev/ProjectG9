using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    //[Header("Camera")]
    //public Camera mainCamera;
    [Header("Movement")]
    public Rigidbody RB;
    public float moveSpeed = 4.5f;
    private Vector3 inputDirection;
    private Vector3 movement;
    // InputActions
    PlayerInputActions inputAction;
    // Move
    Vector2 movementInput;
    public bool KeyboardPruebas = false;

    public Gamepad gamepad_current;
    public int PlayerNum;

    public bool canmove = true;
    GameObject a = null;
    private int StunDuration = 0;

    //Vidas y respawn
    public int Lives = 3;
    private bool invul = false;

    void Awake()
    {
        inputAction = new PlayerInputActions();
        inputAction.PlayerControls.Move.performed += ctx =>
        movementInput = ctx.ReadValue<Vector2>();
    }
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody>();
        if (gamepad_current == null && KeyboardPruebas == false)
        {
            Debug.LogError("Gamepad not initialize");
            return;
        } 
        else if(gamepad_current != null && KeyboardPruebas == true)
        {
            Debug.Log("I am player number " + PlayerNum.ToString() + "with Gamepad name: " + gamepad_current.name);
        }
    }
    void Update()
    {
        //transform.position += new Vector3(0, 0, 0.1f);
    }
    void GamePadController()
    {
        //GAMEPAD//////////////
        //var gamepad = Gamepad.current;
        if (canmove)
        {
            if (gamepad_current == null)
            {
                Debug.LogError("Gamepad not detected");
                return;
            }

            //Acelerar con el de RT. 
            if (gamepad_current.rightTrigger.isPressed)
            {
                RB.MovePosition(RB.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
            }

            Vector2 gp = gamepad_current.leftStick.ReadValue();

            if (gp.x > 0.0f)
            {
                RB.MoveRotation(RB.rotation * Quaternion.Euler(0.0f, 100.0f * Time.fixedDeltaTime, 0.0f));
            }
            if (gp.x < 0.0f)
            {
                RB.MoveRotation(RB.rotation * Quaternion.Euler(0.0f, -100.0f * Time.fixedDeltaTime, 0.0f));
            }
        }
        ////////////////////
    }

    private void FixedUpdate()
    {
        //Input: Keyboard.
        if (canmove)
        {
            if (KeyboardPruebas)
            {
                float h = movementInput.x;
                float v = movementInput.y;
                Vector3 Mov = new Vector3(h, v, 0.0f);
                Debug.Log(Mov);
                RB.MovePosition(RB.position + new Vector3(Mov.x, 0.0f, Mov.y) * moveSpeed * Time.fixedDeltaTime); // Movimiento en XY. 
            }
            else
            {
                GamePadController();
            }
        }
        /*
        float h = movementInput.x;
        float v = movementInput.y;
        Vector3 Mov = new Vector3(h, v, 0.0f);
        Debug.Log(Mov);
        RB.MovePosition(RB.position + new Vector3(Mov.x, 0.0f, Mov.y) * moveSpeed * Time.fixedDeltaTime); // Movimiento en XY. 
        */
        
    }

    public void Stun(float segundos)
    {
        canmove = false;
        StartCoroutine(stun(segundos));
    }
    IEnumerator stun(float s)
    {
        yield return new WaitForSeconds(s);//VER COMO HACER SIN HARDCODE
        canmove = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Alquitran>() != null)
        {

            moveSpeed = other.gameObject.GetComponent<Alquitran>().slow;
        }
        else if(other.gameObject.GetComponent<PEM>() != null)
        {
            Stun(other.gameObject.GetComponent<PEM>().stundur);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Alquitran>() != null)
        {


            if (other.gameObject.GetComponent<Alquitran>().IsPinchos)
            {
                StartCoroutine(SlowExtraTime(other.gameObject.GetComponent<Alquitran>().slowDuration));
            }
            else
            {
                moveSpeed = 5.0f;
            }
        }
    }
    IEnumerator SlowExtraTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        moveSpeed = 5.0f;
    }
    public void ChangeSpeed(float _newSpeed)
    {
        moveSpeed = _newSpeed;
    }
    public void Death()
    {
        Lives--;
    }

    //NO TOCAR ESTAS FUNCIONES, O NO IRA EL INPUT.
    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }
    //////////////
}

/*
 
    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Rigidbody RB;
    Vector3 Mov;
    public bool canmove = true;
    GameObject a = null;
    private int StunDuration=0;


     public void Stun(int segundos)
    {
        canmove = false;
        StartCoroutine(stun(segundos));
    }
    IEnumerator stun(float s)
    {
        yield return new WaitForSeconds(3);//VER COMO HACER SIN HARDCODE
        canmove = true;
    }
    public void DMG(float dmg)
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Alquitran>() != null)
        {

            a = other.gameObject;
            moveSpeed = other.gameObject.GetComponent<Alquitran>().slow;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Alquitran>() != null)
        {

            moveSpeed =5.0f;
        }
    }
    public void ChangeSpeed(float _newSpeed)
    {
        moveSpeed = _newSpeed;
    }
    */


/*
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Header("Camera")]
    public Camera mainCamera;
    [Header("Movement")]
    public Rigidbody RB;
    public float moveSpeed = 4.5f;
    private Vector3 inputDirection;
    private Vector3 movement;
    // InputActions
    PlayerInputActions inputAction;
    // Move
    Vector2 movementInput;

    void Awake()
    {
        inputAction = new PlayerInputActions();
        inputAction.PlayerControls.Move.performed += ctx =>
        movementInput = ctx.ReadValue<Vector2>();
    }
    void Start()
    {     
        RB = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
    }
    void Gamepad()
    {
        ///GAMEPA//////////////
        //var gamepad = Gamepad.current;
        //if (gamepad == null)
        //    return;

        ////Acelerar con el de RT. 
        //if (gamepad.rightTrigger.isPressed)
        //{
        //    RB.MovePosition(RB.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
        //}

        //Vector2 gp = gamepad.leftStick.ReadValue();

        //if(gp.x > 0.0f)
        //{
        //    RB.MoveRotation(RB.rotation * Quaternion.Euler(0.0f , 100.0f * Time.fixedDeltaTime, 0.0f));
        //}
        //if (gp.x < 0.0f)
        //{
        //    RB.MoveRotation(RB.rotation * Quaternion.Euler(0.0f, -100.0f * Time.fixedDeltaTime, 0.0f));
        //}
        ////////////////////
    }
    private void FixedUpdate()
    {
        float h = movementInput.x;
        float v = movementInput.y;

        Vector3 Mov = new Vector3(h, v, RB.position.z);
        Debug.Log(Mov);
       
        RB.MovePosition(RB.position + Mov * moveSpeed * Time.fixedDeltaTime); // Movimiento en XY.       

    }
    public void Stun(int segundos)
    {
    }
    public void DMG (float dmg)
    {
    }
    //NO TOCAR ESTAS FUNCIONES, O NO IRA EL INPUT.
    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }
    //////////////
}
*/
