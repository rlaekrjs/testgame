using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class item_whiteBloodCell : MonoBehaviour
{
    [SerializeField]
    private int whiteBloodCell_HP = 8;
    [SerializeField]
    private float whiteBloodCell_speed = 0.04f;
    [SerializeField]
    public GameObject[] item;
    

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
        transform.localPosition += new Vector3(0, -whiteBloodCell_speed, 0);

    }
    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("bullet"))
        {
            whiteBloodCell_HP--;
            //아이템 몬스터 체력 감소
            Destroy(collisionInfo.gameObject);
            //충돌한 총알 파괴
            if (whiteBloodCell_HP <= 0)
            {
                Die();
            }//체력이 0이하일때 백혈구 파괴
        }
        if (collisionInfo.gameObject.CompareTag("kill box"))
        {
            Destroy(gameObject);
        }
    }
    void Die()
    {
        Vector3 spawnPos = transform.position;
        //Instantiate(item[Random.Range(0, 4)]).transform.position = transform.position;
        int animaIIndex = Random.Range(0, item.Length);
        Instantiate(item[animaIIndex], spawnPos,
        item[animaIIndex].transform.rotation);
        Destroy(gameObject);
    }
}
