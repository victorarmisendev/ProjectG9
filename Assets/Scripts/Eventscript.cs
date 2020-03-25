using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventscript : MonoBehaviour
{
    public GameObject Disapear;
    public float TimeOn;
    public float TimeOf;
    // Start is called before the first frame update
    void Start()
    {
        MakeDisapear();
    }
   
    void MakeDisapear()
    {
        Disapear.SetActive(false);
        StartCoroutine(WaittoApear());
    }
    void MakeApear()
    {
        Disapear.SetActive(true);
        StartCoroutine(WaittoDisapear());
    }
    IEnumerator WaittoApear()
    {
        yield return new WaitForSeconds(TimeOf);
        MakeApear();

    }
    IEnumerator WaittoDisapear()
    {
        yield return new WaitForSeconds(TimeOn);
        MakeDisapear();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
