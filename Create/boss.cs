using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEditor.Progress;

public class boss : MonoBehaviour
{
    public GameObject[] monster;
    [SerializeField]
    public int boss_HP = 100;
    private float spawnRangeX = 1.1f;
    private float spawnposZ = 20;

    public float nextfireQ, firerateQ = 0.1f;
    public float random = 0, Bulletspeed = 10;

    protected GameObject bullet;
    protected Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        void Die()
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX,
               spawnRangeX), 5.4f, spawnposZ);
            int animaIIndex = Random.Range(0, monster.Length);
            Instantiate(monster[animaIIndex], spawnPos,
            monster[animaIIndex].transform.rotation);
            
        }
    }
    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("bullet"))
        {
            boss_HP--;
            //몬스터 체력 감소
            Destroy(collisionInfo.gameObject);
            //충돌한 총알 파괴
            if (boss_HP <= 0)
            {
                Gamemanager.instance_.score += 5000;
                Destroy(gameObject);
                Gamemanager.instance_.SetText();

            }//체력이 0이하일때 몬스터 파괴
        }
    }
    protected void FixedUpdate()
    {
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
        for (int i = 1; i <= 3; i++)
        {
            inst.transform.position = transform.position;
            inst.GetComponent<enemy_bullet>().toVector = Gamemanager.VectorRotation(Gamemanager.PointDirection(transform.position, player.transform.position) + ((2 - i) * 10));
            inst.GetComponent<enemy_bullet>().speed = Bulletspeed;

        }
    }
}
