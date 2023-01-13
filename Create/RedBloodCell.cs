using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBloodCell : MonoBehaviour
{
    [SerializeField]
    protected int RedBloodCell_HP = 6;
    [SerializeField]
    private float RedBloodCell_speed = 0.04f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected void FixedUpdate()
    {
        transform.localPosition += new Vector3(0, -RedBloodCell_speed, 0);

    }
    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("bullet"))
        {
            RedBloodCell_HP--;
            //적혈구 체력 감소
            Destroy(collisionInfo.gameObject);
            //충돌한 총알 파괴
            if (RedBloodCell_HP <= 0)
            {
                Gamemanager.instance_.GetComponent<pain_gauge>().gauge_Update(false);
                Destroy(gameObject);
            }//체력이 0이하일때 적혈구 파괴 고통 게이지 감소
        }
        if (collisionInfo.gameObject.CompareTag("kill box"))
        {
            Destroy(gameObject);
        }
    }
}
