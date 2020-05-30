using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(stun(2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator stun(float s)
    {
        yield return new WaitForSeconds(3);//VER COMO HACER SIN HARDCODE
        SceneManager.LoadScene("MenuPrincipal");
    }
}
