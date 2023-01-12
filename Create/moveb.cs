using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveb : MonoBehaviour
{
    [SerializeField]

    float bullet_speed = 0.1f;
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        float moveY = bullet_speed * Time.deltaTime;
        transform.Translate(0, moveY, 0);

    }
}