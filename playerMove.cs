using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    [SerializeField]
    float v_speed = 0.1f;
    Vector2 speedNomal;
    void Start()
    {
        
    }

    
    void Update()
    {
        moveControl();
    }

    void moveControl()
    {
        float h = Input.GetAxis("Horizontal");
        //좌우입력 받기
        float v = Input.GetAxis("Vertical");
        //상하 이동 받기
        speedNomal = (new Vector2(h, v));
        // 벡터에 입력
        if (speedNomal.magnitude > 1)
            speedNomal = speedNomal.normalized;
        //백터 노멀라이즈(정규화)
        transform.Translate(speedNomal * (v_speed));
        //벡터에 곱해줌
    }
}
