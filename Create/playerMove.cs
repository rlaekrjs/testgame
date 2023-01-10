using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    [SerializeField]
    float v_speed = 0.1f;
    Vector2 speedNomal;
    int playerHP = 10;
    void Start()
    {
     
    }
    private void OnEnable()
    {
        Gamemanager.instance_.player= this;
    }

    void Update()
    {
    }
    private void FixedUpdate()
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
    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("enemy_attack"))
        {
            playerHP--;
            Gamemanager.instance_.GetComponent<Userlnterface>().HealthBar_Update(true);
            //�÷��̾� ü�� ����
            Destroy(collisionInfo.gameObject);
            //�浹�� �Ѿ� �ı�
            if (playerHP <= 0)
                Destroy(gameObject);
            //ü���� 0�����϶� ���� �ı�
        }
    }
}
