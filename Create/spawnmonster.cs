using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class spawnmonster : MonoBehaviour
{
    public GameObject[] monster;
    public GameObject[] item_monster;
    public GameObject bossspawn;
    
    private float spawnRangeX = 2.5f;
    private float spawnposZ = 20;
    float monstrTime;
    float itemTime;
    float bossTime;
    int randomtime=1;
    int randomtime2=5;
    bool isspawnboss = false;
    void Start()
     {
            
     }
    void Update()
    {
        
        monstrTime += Time.deltaTime;
        itemTime += Time.deltaTime;
        bossTime += Time.deltaTime;
        //Debug.Log(currTime);
        if (monstrTime > randomtime)
        {
            randomtime = Random.Range(1, 7);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX,
               spawnRangeX), 5.4f, spawnposZ);
            int animaIIndex = Random.Range(0, monster.Length);
            Instantiate(monster[animaIIndex], spawnPos,
                monster[animaIIndex].transform.rotation);
            monstrTime = 0;
        }

        if (itemTime > randomtime2)
        {
            Debug.Log("1");
            randomtime2 = Random.Range(10,15);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX,
               spawnRangeX), 5.4f, spawnposZ);
            int animaIIndex = Random.Range(0, item_monster.Length);
            Instantiate(item_monster[animaIIndex], spawnPos,
                item_monster[animaIIndex].transform.rotation);
            itemTime = 0;
        }
        if (bossTime > 30&&isspawnboss==false)
        {

            Vector3 spawnPos = new Vector3(0, 3, 0);

            Instantiate(bossspawn, spawnPos,
                bossspawn.transform.rotation);
            isspawnboss = true;

        }
    }
}
