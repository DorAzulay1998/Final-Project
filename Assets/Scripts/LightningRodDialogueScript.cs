using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningRodDialogueScript : MonoBehaviour
{
    public GameObject LightningRodDialogue;

    private void Start()
    {
        LightningRodDialogue.SetActive(false);    
    }
    
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            LightningRodDialogue.SetActive(true);
        }
    }

    
    void OnTriggerExit(Collider other) 
    {
        LightningRodDialogue.SetActive(false);
    }
}
