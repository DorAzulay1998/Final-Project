using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallDialogueScript : MonoBehaviour
{
    public GameObject fireBallDialogue;

    private void Start()
    {
        fireBallDialogue.SetActive(false);    
    }
    
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            fireBallDialogue.SetActive(true);
        }
    }

    
    void OnTriggerExit(Collider other) 
    {
        fireBallDialogue.SetActive(false);
    }
}
