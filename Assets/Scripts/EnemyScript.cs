using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    float enemyHP;
    void Start()
    {
        enemyHP = 10;
    }

    void Update()
    {
        Death();
    }

    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "FireBall")
        {
            enemyHP -= 2;
        }
        if(other.gameObject.tag == "LightningRod")
        {
            enemyHP -= 5;
        }
    }

    void Death()
    {
        if(enemyHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
