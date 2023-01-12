using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_bullet : MonoBehaviour
{
    [SerializeField]

    public GameObject bullet;
    [SerializeField]

    float shootDelay = 0.5f;

    float latetime;

    void Start()
    {
        latetime = Time.time + shootDelay;    
    }

    // Update is called once per frame
    void Update()
    {
        if(latetime<=Time.time&&Input.GetKey(KeyCode.X))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            latetime = Time.time + shootDelay;

        }

    }
}
