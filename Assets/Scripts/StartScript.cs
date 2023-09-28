using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    //start
    public void startgame()
    {
        SceneManager.LoadScene(1);
    }

    //Quit
    public void Quit()
    {
        Application.Quit();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    public void Options()
    {
        print("We dont really have that yet...");
    }
}
