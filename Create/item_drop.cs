using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_drop : MonoBehaviour
{
    [SerializeField]
    public float item_speed=0.04f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void FixedUpdate()
    {
        transform.localPosition += new Vector3(0, -item_speed, 0);
    }


}
