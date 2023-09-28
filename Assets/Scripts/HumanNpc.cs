using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HumanNpc : MonoBehaviour
{
    GameObject player;
    Vector3 targetPosition;
    bool goodDistance;
    public GameObject canvas;
    public TextMeshProUGUI firstDialogue;
    public GameObject[] dialogueImages = new GameObject[5];
    int dialogueNum;
    Vector3 teleportPoint = new Vector3(481.5f, -0.006249428f, 572.2f);
    Animator hit;
    void Start()
    {
        player = GameObject.Find("Player");
        dialogueNum = 0;
        hit = GetComponent<Animator>();
    }

    void Update()
    {
        LookAtPlayer();
        TeleportTime();
        
    }

    public void LookAtPlayer()
    {
        targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        if(Vector3.Distance(player.transform.position, transform.position) <= 10)
        {
            transform.LookAt(targetPosition);
            firstDialogue.text = "Press F";
            if(Input.GetKeyDown(KeyCode.F))
            {
                dialogueNum += 1;
                canvas.SetActive(false);
                dialogueImages[0].SetActive(true);
                if(Vector3.Distance(player.transform.position, transform.position) <= 10 && dialogueNum >= 2)
                {
                    dialogueImages[0].SetActive(false);
                    dialogueImages[1].SetActive(true);
                    if(Vector3.Distance(player.transform.position, transform.position) <= 10 && dialogueNum >= 3)
                    {
                        dialogueImages[1].SetActive(false);
                        dialogueImages[2].SetActive(true);
                        if(Vector3.Distance(player.transform.position, transform.position) <= 10 && dialogueNum >= 4)
                        {
                            dialogueImages[2].SetActive(false);
                            dialogueImages[3].SetActive(true);
                            if(Vector3.Distance(player.transform.position, transform.position) <= 10 && dialogueNum >= 5)
                            {
                                dialogueImages[3].SetActive(false);
                                dialogueImages[4].SetActive(true);
                                Invoke("GiveHit", 3);
                                if(Vector3.Distance(player.transform.position, transform.position) <= 10 && dialogueNum >= 6)
                                {
                                    dialogueImages[4].SetActive(false);
                                    dialogueImages[5].SetActive(true);
                                }
                            }
                        }
                    }
                }
            }
        }
        else
        {
            firstDialogue.text = "";
            for(int i = 0; i < dialogueImages.Length; i++)
            {
                dialogueImages[i].SetActive(false);
            }
        }
    }

    void Teleport()
    {
        transform.position = teleportPoint;
    }

    void TeleportTime()
    {
        if(dialogueNum >= 3)
        {
            Invoke("Teleport", 5);
        }
    }

    void GiveHit()
    {
        hit.SetTrigger("Hit");
    }
}
