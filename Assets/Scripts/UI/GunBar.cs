using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunBar : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = 4;
        slider.value = 4;
    }

    public void setValue(float nValue)
    {
        slider.value = nValue;
    }
}
