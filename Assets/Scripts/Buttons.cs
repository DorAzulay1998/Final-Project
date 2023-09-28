using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void SorcererBTN()
    {
        SceneManager.LoadScene(2);
    }

    public void NothingBTN()
    {
        print("Not Ready Yet!");
    }
}
