using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    float shootingSpeed;
    public Rigidbody rb;
    AudioSource fireBallSound;
    void Start()
    {
        shootingSpeed = 6000f * Time.deltaTime;
        rb.velocity = transform.forward * shootingSpeed;
        fireBallSound = GetComponent<AudioSource>();
        fireBallSound.Play();
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Target" || other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
