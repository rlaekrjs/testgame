using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Userlnterface : MonoBehaviour
{
    public Slider HealthBar;

    private void Update()
    {

    }
    public void HealthBar_Update(bool a)
    {
        if (a)
        {
            HealthBar.value -= 0.05f;
        }
        else HealthBar.value += 0.05f;
    }
}
