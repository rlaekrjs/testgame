using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_parents : MonoBehaviour
{
    [SerializeField]
    protected int monster_HP = 10;
    [SerializeField]
    protected float monster_speed = 0.02f;

    public float nextfireQ, firerateQ = 0.1f;
    public float random = 0, Bulletspeed = 10;
    [SerializeField]
    protected GameObject bullet;
    protected Transform player;
    protected void Start()
    {
        player = Gamemanager.instance_.player.transform;
    }

    // Update is called once per frame
    protected void Update()
    {
       
    }
    protected void FixedUpdate()
    {
        transform.localPosition += new Vector3(0, -monster_speed, 0);
        if (Time.time > nextfireQ)
            fire();

    }
    protected virtual void fire()
    {
        nextfireQ = Time.time + firerateQ + Random.Range(0.3f, 1.0f);
        GameObject inst = Instantiate(bullet);
        inst.transform.position = transform.position;
        //Debug.Log((Vector2)player.transform.position);
        inst.GetComponent<enemy_bullet>().toVector = Gamemanager.VectorRotation(
            Gamemanager.PointDirection(transform.position, player.transform.position)
            + Random.Range(-random, random));
        inst.GetComponent<enemy_bullet>().speed = Bulletspeed;

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
            {
                Gamemanager.instance_.score += 500;
                Destroy(gameObject);
                Gamemanager.instance_.SetText();

            }//체력이 0이하일때 몬스터 파괴
        }
        if (collisionInfo.gameObject.CompareTag("kill box"))
        {
            Gamemanager.instance_.GetComponent<pain_gauge>().gauge_Update(true);
            
            Destroy(gameObject);
        }
    }
}
