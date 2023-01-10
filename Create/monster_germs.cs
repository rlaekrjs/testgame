using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_germs : monster_parents
{
    public float nextfireQ, firerateQ = 0.1f;
    public float random = 0, Bulletspeed = 10;
    [SerializeField]
    private GameObject bullet;
    Transform player;
    void Start()
    {
        player = Gamemanager.instance_.player.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        transform.localPosition += new Vector3(0, 0, 0);
        if (Time.time > nextfireQ)
            fire();

    }
    void fire()
    {
        nextfireQ = Time.time + firerateQ + Random.Range(-1.0f, 1.0f);
        GameObject inst = Instantiate(bullet);
        inst.transform.position = transform.position;
        //Debug.Log((Vector2)player.transform.position);
        inst.GetComponent<enemy_bullet>().toVector = Gamemanager.VectorRotation(
            Gamemanager.PointDirection(transform.position, player.transform.position)
            + Random.Range(-random, random));
        inst.GetComponent<enemy_bullet>().speed = Bulletspeed;

    }
}
