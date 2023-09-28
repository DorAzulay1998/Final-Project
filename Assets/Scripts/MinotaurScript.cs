using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurScript : MonoBehaviour
{
    Vector3 playerPos;
    GameObject player;
    Rigidbody rb;
    Animator minAnim;
    int minotaurLives;    

    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        minAnim = GetComponent<Animator>();
        minotaurLives = 15;
    }

    void Update()
    {
        LookAndMoveToPlayer();
        DeathAnim();
    }

    void LookAndMoveToPlayer()
    {
        playerPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        if(Vector3.Distance(player.transform.position, transform.position) <= 35)
        {
            transform.LookAt(playerPos);
            Vector3 pos = Vector3.MoveTowards(transform.position, player.transform.position, 10 * Time.deltaTime);
            rb.MovePosition(pos);
            minAnim.SetBool("isMoving", true);
            if(Vector3.Distance(player.transform.position, transform.position) <= 10)
            {
                minAnim.SetTrigger("Attack");
            }
        }
        else
        {
            minAnim.SetBool("isMoving", false);
        }

    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "FireBall")
        {
            minotaurLives -= 2;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "LightningRod")
        {
            minotaurLives -= 5;
            Destroy(other.gameObject);
        }
    }
    void Death()
    {
        Destroy(gameObject);
    }
    void DeathAnim()
    {
        if(minotaurLives <= 0)
        {
            minAnim.SetTrigger("Dead");
            Invoke("Death", 2f);
        }
    }
}
