using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicCheckScript : MonoBehaviour
{
    public GameObject micCheckIMJ;

    private void Start() 
    {
        micCheckIMJ.SetActive(false);
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            micCheckIMJ.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            micCheckIMJ.SetActive(false);
        }
    }
}
