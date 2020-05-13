using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementShoot : MonoBehaviour
{

    public GameObject Bullet;
    public GameObject BulletSP;
    public GameObject Trap;
    public GameObject TrampSP;
    public Vector3 g;
    public bool Canshoot = true;
    private float CD = 4.0f;
    private float timeinCD = 0;
    public GunBar bar;
    private Rigidbody RB;
    private PlayerControler PC;
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        PC = GetComponent<PlayerControler>();
    }

    void FixedUpdate()
    {
        Plane PlayerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);

        Trap = PC.currentTrap;
        //Acelerar con el de RT. 
        if (PC.gamepad_current.leftTrigger.isPressed && Canshoot)
        {
            bar.setValue(0);
            Shoot(0);
           
        }
        else if(PC.gamepad_current.aButton.isPressed && Canshoot)
        {
            bar.setValue(0);
            Shoot(1);
        }
        else if (PC.gamepad_current.bButton.isPressed && Canshoot)
        {
            bar.setValue(0);
            Shoot(2);
        }
        else if (PC.gamepad_current.xButton.isPressed && Canshoot)
        {
            bar.setValue(0);
            Shoot(3);
        }
        else if (PC.gamepad_current.yButton.isPressed && Canshoot)
        {
            bar.setValue(0);
            Shoot(4);
        }
    }
   public void ChangeBar(GunBar a)
    {
        bar = a;
    }
    void Shoot(int num)
    {
        Vector3 pos=new Vector3(0, 0, 0); ;
        switch (num)
        {
            case 0:
                pos = new Vector3(27, 0, PC.CameraKill.transform.position.z + 125f);
                break;
            case 1:
                pos = new Vector3(12, 0, PC.CameraKill.transform.position.z + 125f);
                break;
            case 2:
                pos = new Vector3(-2, 0, PC.CameraKill.transform.position.z + 125f);
                break;
            case 3:
                pos = new Vector3(-18, 0, PC.CameraKill.transform.position.z + 125f);
                break;
            case 4:
                pos = new Vector3(-33, 0, PC.CameraKill.transform.position.z + 125f);
                break;
            default:
                break;
        }
        
       Instantiate(Bullet.transform, pos, BulletSP.transform.rotation);
       Canshoot = false;
       StartCoroutine(Cooldown());
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1);
        timeinCD++;
        if(timeinCD<4)
        {
            bar.setValue(timeinCD);
            StartCoroutine(Cooldown());
           
        }
        else
        {
            bar.setValue(timeinCD);
            Canshoot = true;
            timeinCD = 0;
        }
        
    }
}
