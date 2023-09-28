using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    public float zombieLives;
    GameObject player;
    Vector3 playerPos;
    Rigidbody rb;
    bool isMoving;
    public bool zombieDead;
    public AnimationClip[] zombieAnimClip = new AnimationClip[7];
    Animation zombieAnim;
    public BoxCollider leftHand;
    public BoxCollider rightHand;
    void Start()
    {
        zombieLives = 10f;
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        isMoving = false;
        zombieAnim = GetComponent<Animation>();
        zombieAnim.clip = zombieAnimClip[4];
        zombieAnim.Play();
        zombieDead = false;
    }

    void Update()
    {
        Death();
        LookAndMoveToPlayer();
        ZombieAnimation();
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "FireBall")
        {
            zombieLives -= 2f;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "LightningRod")
        {
            zombieLives -= 5f;
            Destroy(other.gameObject);
        }
    }

    void LookAndMoveToPlayer()
    {
        playerPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        if(Vector3.Distance(player.transform.position, transform.position) <= 20)
        {
            isMoving = true;
            transform.LookAt(playerPos);
            Vector3 pos = Vector3.MoveTowards(transform.position, player.transform.position, 8 * Time.deltaTime);
            rb.MovePosition(pos);
        }
        else
        {
            isMoving = false;
        }
        
    }

    void ZombieAnimation()
    {
        if(isMoving)
        {
            zombieAnim.clip = zombieAnimClip[1];
            zombieAnim.Play();

        }
        else
        {
            zombieAnim.clip = zombieAnimClip[4];
            zombieAnim.Play();
        }
    }

    void Death()
    {
        if(zombieLives <= 0)
        {
            zombieDead = true;
            TestDialogueScript2.instance.DeathCounter();
            Destroy(gameObject);
        }
    }
}
