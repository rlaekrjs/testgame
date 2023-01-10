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
            //몬스터 체력 감소
            Destroy(collisionInfo.gameObject);
            //충돌한 총알 파괴
            if (monster_HP <= 0)
            Destroy(gameObject);
            //체력이 0이하일때 몬스터 파괴
        }
    }
}
