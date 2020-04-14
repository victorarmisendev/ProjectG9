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
    public float moveSpeed, speed = 0.0f, acceleration = 100.5f , mSpeed = 10.0f, speedPlayer;
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
    public GameObject CameraKill;
    public float respawnX;
    GameObject[] otherCars;
    public bool invulnerable = false;

    public Text canvas;

    private bool forward = false;

    void Awake()
    {
        inputAction = new PlayerInputActions();
        inputAction.PlayerControls.Move.performed += ctx =>
        movementInput = ctx.ReadValue<Vector2>();
    }
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody>();
        speedPlayer = Camera.main.GetComponent<CameraFollow>().speed + 2;
        moveSpeed = speedPlayer;
        if (gamepad_current == null)
        {
            Debug.LogError("Gamepad not initialize");
            return;
        }
        //Debug.Log("I am player number " + PlayerNum.ToString() + "with Gamepad name: " + gamepad_current.name);
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
            if(speed >= 0.0f)
            {
                forward = true;
            } 
            else 
            {
                forward = false;
            }
            //Translation and acceleration. 
            if (gamepad_current.rightTrigger.isPressed && forward)
            {
                speed = speed + acceleration * Time.fixedDeltaTime;
                
            }
            else if (!gamepad_current.rightTrigger.isPressed)
            {
                speed = speed - acceleration * Time.fixedDeltaTime;                
            }
            speed = Mathf.Clamp(speed, 0.0f, 0.2f);
            //Debug.Log("Speed is: " + speed); //Debug.Log funcionan inestables en fixedUpdate
            RB.MovePosition(RB.position + transform.forward * speed * Time.fixedDeltaTime * (this.speedPlayer*5.5f));
            //Rotation car.
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

        //public void forceField()
        //{
        //    otherCars = GameObject.FindGameObjectsWithTag("Base");
        //    foreach(GameObject obj in otherCars)
        //    {

        //        float dist = Vector3.Distance(obj.transform.position, transform.position);
        //        if (dist != 0 && dist <= 10)
        //        {

        //            obj.GetComponent<PlayerControler>().forceFieldReaction(transform.position);
        //        }
        //    }
        //}

        //public void forceFieldReaction(Vector3 otherPosition)
        //{
        //    Vector3 forceDirection = transform.position - otherPosition;
        //    RB.AddForce(forceDirection * 20);
        //}

    public void Stun(float segundos)
    {
        canmove = false;
        Debug.Log("hey");
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
        else if (other.tag == "End")
        {
            Death();
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
    private void OnCollisionEnter(Collision collision)
    {
        
    }
    IEnumerator SlowExtraTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        moveSpeed = 15.0f;
    }
    public void ChangeSpeed(float _newSpeed)
    {
        moveSpeed = _newSpeed;
    }
    public void Death()
    {
        if (!invulnerable)
        {
            Lives--;
            Debug.Log(Lives);
            canvas.text = "Lives " + Lives;
            float x = 0;
            ChangeSpeed(speedPlayer);
            switch (respawnX)
            {
                case 0:
                    x = -12;
                    break;
                case 1:
                    x = -2;
                    break;
                case 2:
                    x = 2;
                    break;
                case 3:
                    x = 12;
                    break;
                default:
                    break;
            }
            gameObject.transform.position = new Vector3(x, 1, CameraKill.transform.position.z + 15);
            invul = true;
            /*if(Lives<=0)
            {
                Destroy(gameObject);
            }*/
            StartCoroutine(InvulCD());
        }
    }
    IEnumerator InvulCD()
    {
        yield return new WaitForSeconds(3);
        invul = false;
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


