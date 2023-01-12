using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pain_gauge : MonoBehaviour
{
    public Slider gauge;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gauge_Update(bool a)
    {
        if (a)
        {
            gauge.value += 0.2f;

        }
        else
        {
            
            gauge.value += 0.2f;

        }
    }
}
