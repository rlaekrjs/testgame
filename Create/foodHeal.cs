using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class foodHeal : item_drop
{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }
}
