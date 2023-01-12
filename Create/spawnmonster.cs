using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmonster : MonoBehaviour
{
    public GameObject[] animaIPrefab;
    private float spawnRangeX = 2.5f;
    private float spawnposZ = 20;
    float currTime = 7;
    void Start()
     {
            
     }
    void Update()
    {
        currTime += Time.deltaTime;
        //Debug.Log(currTime);
        if (currTime > 7)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX,
               spawnRangeX), 5.4f, spawnposZ);
            int animaIIndex = Random.Range(0, animaIPrefab.Length);
            Instantiate(animaIPrefab[animaIIndex], spawnPos,
                animaIPrefab[animaIIndex].transform.rotation);
            currTime = 0;
        }
    }
}
