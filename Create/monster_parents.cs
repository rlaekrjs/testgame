using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_parents : MonoBehaviour
{
    [SerializeField]

    protected int monster_HP = 10;

    protected float monster_speed = 1;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if(collisionInfo.gameObject.CompareTag("bullet"))
        {
            monster_HP--;
            //���� ü�� ����
            Destroy(collisionInfo.gameObject);
            //�浹�� �Ѿ� �ı�
            if (monster_HP <= 0)
            Destroy(gameObject);
            //ü���� 0�����϶� ���� �ı�
        }
    }
}
