using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(("Enemy")))
        {
            //destroy enemy when collide
            Destroy(collision.gameObject);
        }    
    }
}
