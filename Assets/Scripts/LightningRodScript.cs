using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningRodScript : MonoBehaviour
{
    float shootLightning;
    public Rigidbody rb;
    AudioSource sound;
    void Start()
    {
        shootLightning = 10000f * Time.deltaTime;
        rb.velocity = transform.forward * shootLightning;
        sound = GetComponent<AudioSource>();
        sound.Play();
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
