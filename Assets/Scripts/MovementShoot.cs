using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementShoot : MonoBehaviour
{


    public GameObject Bullet;
    public GameObject BulletSP;
    public Vector3 g;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Plane PlayerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist = 0.0f;
        g = BulletSP.transform.position;
        if(PlayerPlane.Raycast(ray, out hitdist))
        {
            Vector3 TargetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(TargetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 7f * Time.deltaTime);
        }
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
 
    void Shoot()
    {
        Instantiate(Bullet.transform, BulletSP.transform.position, BulletSP.transform.rotation);
    }
}
