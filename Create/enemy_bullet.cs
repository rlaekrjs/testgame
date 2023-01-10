using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet : MonoBehaviour
{
    public Vector3 toVector;
    public float speed = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        transform.Translate(toVector*Time.deltaTime*speed);
        Destroy(gameObject, 5);
    }
}
