using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerMove : MonoBehaviour
{
    
    [SerializeField]
    float v_speed = 0.1f;
    Vector2 speedNomal;
    public float playerHP = 10;
    public int gauge;
    public float invincibilityTime = 3;
    SpriteRenderer sr;
    void Start()
    {
        
    }
    private void OnEnable()
    {
        Gamemanager.instance_.player= this;
    }

    void Update()
    {
        //�÷��̾� �� ��Ż ���� �ڵ�
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);

        //����������� �� ���� �÷��̾� ���
        if (Gamemanager.instance_.GetComponent<pain_gauge>().gauge.value >= 1)
        {
            Destroy(gameObject);
        }

        invincibilityTime += Time.deltaTime;
        if (invincibilityTime < 1.5f)
        {
            sr = GetComponent<SpriteRenderer>();
            sr.color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            sr = GetComponent<SpriteRenderer>();
            sr.color = new Color(1, 1, 1, 1);
        }
        if (playerHP <= 0)
            Destroy(gameObject);

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
            if (invincibilityTime > 1.5f)
            {
                invincibilityTime = 0;
                playerHP -= 0.5f;
                Gamemanager.instance_.GetComponent<Userlnterface>().HealthBar_Update(true);
            }
            //�÷��̾� ü�� ����
            Destroy(collisionInfo.gameObject);
            //�浹�� �Ѿ� �ı�
        }
        if (collisionInfo.gameObject.tag.Equals("item"))
        {
            //�÷��̾ ������ �Ծ����� ü�� ȸ��
            if (playerHP < 10)
            {
                playerHP+=0.5f;
                Gamemanager.instance_.GetComponent<Userlnterface>().HealthBar_Update(false);
            }
            Destroy(collisionInfo.gameObject);
        }
        if (collisionInfo.gameObject.CompareTag("monster"))
        {
            //�÷��̾ ���Ϳ� �浹�� ���� �ı� ��������� ���� ü�� ����
            invincibilityTime = 0;
            playerHP -= 0.5f;
            Gamemanager.instance_.GetComponent<Userlnterface>().HealthBar_Update(true);
            Gamemanager.instance_.GetComponent<pain_gauge>().gauge_Update(true);
            Destroy(collisionInfo.gameObject);
        }
        if (collisionInfo.gameObject.CompareTag("item monster"))
        {
            //�÷��̾ ������ ���Ϳ� �浹�� ������ ���� �ı� ü�� ����
            invincibilityTime = 0;
            playerHP -= 0.5f;
            Gamemanager.instance_.GetComponent<Userlnterface>().HealthBar_Update(true);
            Destroy(collisionInfo.gameObject);
        }
        if (collisionInfo.gameObject.CompareTag("boss"))
        {
            //�÷��̾ ������ �浹�� ������ ���� �ı� ü�� ����
            invincibilityTime = 0;
            playerHP -= 0.5f;
            Gamemanager.instance_.GetComponent<Userlnterface>().HealthBar_Update(true);
            Gamemanager.instance_.GetComponent<pain_gauge>().gauge_Update(true);
        }
    }

    
}
