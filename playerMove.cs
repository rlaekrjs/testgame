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
        //�¿��Է� �ޱ�
        float v = Input.GetAxis("Vertical");
        //���� �̵� �ޱ�
        speedNomal = (new Vector2(h, v));
        // ���Ϳ� �Է�
        if (speedNomal.magnitude > 1)
            speedNomal = speedNomal.normalized;
        //���� ��ֶ�����(����ȭ)
        transform.Translate(speedNomal * (v_speed));
        //���Ϳ� ������
    }
}
