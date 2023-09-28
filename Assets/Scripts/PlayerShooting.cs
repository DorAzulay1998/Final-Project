using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject fireBall;
    public GameObject lightningRod;
    float timer;
    void Start()
    {
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;
        ShootFireBallFunk();
        shootLightningFunk();
    }

    void ShootFireBallFunk()
    {
        {
            if(timer > 1f)
            {
                if(Input.GetKeyDown(KeyCode.Mouse0))
                {
                    GameObject shootFireBall = Instantiate(fireBall, transform.position, transform.rotation);
                    timer = 0;
                }
            }
        }
    }

    void shootLightningFunk()
    {
        if(timer > 3)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                GameObject shootlightningRod = Instantiate(lightningRod, transform.position, transform.rotation);
                timer = 0;
            }
        }
    }
}
