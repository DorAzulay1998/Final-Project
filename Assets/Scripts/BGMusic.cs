using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMusic : MonoBehaviour
{
    private static BGMusic instance = null;
    static AudioSource music;
    public static BGMusic Instance
    {
        get { return instance;}
    }
    void Awake() 
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start() 
    {
        music = GetComponent<AudioSource>();
    }

    void Update() 
    {
        if(SceneManager.sceneCount == 2)
        {
            music.volume = 0.4f;
        }
    }
}
