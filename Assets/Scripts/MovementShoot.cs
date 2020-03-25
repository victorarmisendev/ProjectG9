using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementShoot : MonoBehaviour
{

    public GameObject Bullet;
    public GameObject BulletSP;
    public Vector3 g;
    public bool Canshoot = true;
    private float CD = 4.0f;
    private float timeinCD = 0;
    public GunBar bar;
    private Rigidbody RB;

    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Plane PlayerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist = 0.0f;
        g = BulletSP.transform.position;

        //Calculate Rotation. 
        Vector2 gp = transform.parent.gameObject.GetComponent<PlayerControler>().gamepad_current.rightStick.ReadValue();

        if (gp.x > 0.0f)
        {
            RB.MoveRotation(RB.rotation * Quaternion.Euler(0.0f, 100.0f * Time.fixedDeltaTime, 0.0f));
        }
        if (gp.x < 0.0f)
        {
            RB.MoveRotation(RB.rotation * Quaternion.Euler(0.0f, -100.0f * Time.fixedDeltaTime, 0.0f));       
        }
    
        //Acelerar con el de RT. 
        if (transform.parent.gameObject.GetComponent<PlayerControler>().gamepad_current.rightTrigger.isPressed && Canshoot)
        {
            bar.setValue(0);
            Shoot();
        }

        //RB.rotation = new Quaternion(0.0f, RB.rotation.y, 0.0f, 1.0f);

        //if(PlayerPlane.Raycast(ray, out hitdist))
        //{
        //    Vector3 TargetPoint = ray.GetPoint(hitdist);
        //    Quaternion targetRotation = Quaternion.LookRotation(TargetPoint - transform.position);
        //    targetRotation.x = 0;
        //    targetRotation.z = 0;


        //    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 7f * Time.deltaTime);
        //}
        //if(Input.GetMouseButtonDown(0)&&Canshoot)
        //{
        //    bar.setValue(0);
        //    Shoot();           
        //}
    }
   public void ChangeBar(GunBar a)
    {
        bar = a;
    }
    void Shoot()
    {
        Instantiate(Bullet.transform, BulletSP.transform.position, BulletSP.transform.rotation);
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
