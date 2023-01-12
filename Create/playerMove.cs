using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    [SerializeField]
    float v_speed = 0.1f;
    Vector2 speedNomal;
    public int playerHP = 10;
    public int gauge;
    void Start()
    {
     
    }
    private void OnEnable()
    {
        Gamemanager.instance_.player= this;
    }

    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
        //고통게이지가 꽉 차면 플레이어 사망
        if (Gamemanager.instance_.GetComponent<pain_gauge>().gauge.value >= 1)
        {
            Destroy(gameObject);
        }
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
        if (collisionInfo.gameObject.tag.Equals("food"))
        {
            //플레이어가 음식을 먹었을때 체력 회복
            if (playerHP < 10)
            {
                playerHP++;
                Gamemanager.instance_.GetComponent<Userlnterface>().HealthBar_Update(false);
            }
            Destroy(collisionInfo.gameObject);
        }
        if (collisionInfo.gameObject.CompareTag("monster"))
        {
            //플레이어가 몬스터와 충돌시 몬스터 파괴 고통게이지 증가 체력 감소
            playerHP--;
            Gamemanager.instance_.GetComponent<pain_gauge>().gauge_Update(true);
            Destroy(collisionInfo.gameObject);
        }
    }
}
