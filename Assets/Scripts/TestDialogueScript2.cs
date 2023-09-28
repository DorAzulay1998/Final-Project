using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestDialogueScript2 : MonoBehaviour
{
    public static TestDialogueScript2 instance;
    ZombieScript zombieScript;
    public GameObject Dialogue9;
    public GameObject Dialogue11;
    private int killCount;
    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        zombieScript = GameObject.Find("Ghoul").GetComponent<ZombieScript>();
        killCount = 0;
    }

    void Update()
    {
        EnableDialogue();
    }

    void EnableDialogue()
    {
        if(zombieScript.zombieDead == true)
        {
            Dialogue9.SetActive(true);
            Invoke("DisableDialogue", 10);
        }
        if(killCount == 2)
        {
            Dialogue11.SetActive(true);
        }
    }
    void DisableDialogue()
    {
        zombieScript.zombieDead = false;
        Dialogue9.SetActive(false);
    }
    public void DeathCounter()
    {
        killCount++;
    }
    public void NextLevel()
    {
        if(killCount == 2)
        {
            Invoke("InvokeNextLevel", 10);
        }
    }
    void InvokeNextLevel()
    {
        SceneManager.LoadScene(3);
    }
}
