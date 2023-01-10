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
    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("enemy_attack"))
        {
            playerHP--;
            Gamemanager.instance_.GetComponent<Userlnterface>().HealthBar_Update(true);
            //플레이어 체력 감소
            Destroy(collisionInfo.gameObject);
            //충돌한 총알 파괴
            if (playerHP <= 0)
                Destroy(gameObject);
            //체력이 0이하일때 몬스터 파괴
        }
    }
}
