using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueScript : MonoBehaviour
{

    void Start()
    {
        GameObject.Find("Canvas/Test").GetComponent<TextMeshProUGUI>().text = "Test is Working";
    }

    void Update()
    {
        
    }
}
