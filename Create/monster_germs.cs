using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_germs : monster_parents
{



    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void fire()
    {
        nextfireQ = Time.time + firerateQ + Random.Range(0.3f, 1.0f);
        //GameObject inst = Instantiate(bullet);
        //inst.transform.position = transform.position;
        ////Debug.Log((Vector2)player.transform.position);
        //inst.GetComponent<enemy_bullet>().toVector = Gamemanager.VectorRotation(
        //    Gamemanager.PointDirection(transform.position, player.transform.position)
        //    + Random.Range(-random, random));
        //inst.GetComponent<enemy_bullet>().speed = Bulletspeed;

        for (int i = 1; i <= 3; i++)
        {
            GameObject inst = Instantiate(bullet);
            inst.transform.position = transform.position;
            inst.GetComponent<enemy_bullet>().toVector = Gamemanager.VectorRotation(Gamemanager.PointDirection(transform.position, player.transform.position) + ((2 - i) * 10));
            inst.GetComponent<enemy_bullet>().speed = Bulletspeed;

        }
    }

}
