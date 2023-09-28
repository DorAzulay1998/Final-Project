using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Transform cameraPos;
    float mouseY;
    float mouseX;
    float xAxies;
    float zAxies;
    CharacterController cc;
    public bool isGround;
    float radius;
    public LayerMask groundLayerMask;
    public Transform groundCheck;
    public float gravity;
    Vector3 gravityVelocity;
    float turnSpeed;
    public float moveSpeed;
    float cameraX;
    Vector3 standing = new Vector3(3,3,3);
    Vector3 crouching = new Vector3(3,1.5f,3);
    Vector3 groundVector = new Vector3(500, 10, 296);
    int maxHealth = 10;
    int currentHealth;
    bool playerDead;
    public HealthBar healthBar;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        turnSpeed = 200f;
        moveSpeed = 40f;
        cameraX = 0;
        cc = GetComponent<CharacterController>();

        isGround = false;
        radius = 0.5f;
        gravity = -20.81f;

        transform.localScale = standing;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        playerDead = false;
    }
    void FixedUpdate() 
    {
        if(playerDead == false)
        {
            Invoke("RotateView", 1f);
            Invoke("Movement", 1f);
            GravityAndJump();
            Run();
            Crouch();
        }
        PlayerDeath();
    }
    void Crouch()
    {
        if(Input.GetKey(KeyCode.LeftControl))
        {
            transform.localScale = crouching;
        }
        else
        {
            transform.localScale = standing;
        }
    }
    void Run()
    {
        if(Input.GetKey(KeyCode.LeftShift) && isGround == true)
        {
            moveSpeed = 55f;
        }
        else
        {
            moveSpeed = 40f;
        }
    }
    void GravityAndJump()
    {
        if(Physics.CheckSphere(groundCheck.position, radius, groundLayerMask))
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
        if(isGround == false)
        {
            gravityVelocity.y += gravity * Time.deltaTime;
        }
        else
        {
            gravityVelocity.y = 0;
        }

        if(Input.GetKey(KeyCode.Space) && isGround == true)
        {
            gravityVelocity.y += 15;
        }

        cc.Move(gravityVelocity * Time.deltaTime);
    }
    void RotateView()
    {
        mouseX = Input.GetAxis("Mouse X") * turnSpeed *Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * turnSpeed * Time.deltaTime;

        transform.Rotate(0, mouseX, 0);
        cameraX -= mouseY;
        cameraX = Mathf.Clamp(cameraX, -90f, 90f);
        cameraPos.localRotation = Quaternion.Euler(cameraX, 0, 0);
    }
    void Movement()
    {
        xAxies = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        zAxies = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 v = transform.right * xAxies + transform.forward * zAxies;
        cc.Move(v);
    }
    void PlayerDeath()
    {
        if(currentHealth <= 0)
        {
            playerDead = true;
            SceneManager.LoadScene(4);
        }
    }
    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Zombie")
        {
            currentHealth -= 2;
            healthBar.SetHealth(currentHealth);
        }
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "MinotaurAxe")
        {
            currentHealth -= 3;
            healthBar.SetHealth(currentHealth);
        }
    }
}
