using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    [SerializeField]
    private float defaultSpeed;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;
    public float deathHeight;
    private float moveInput;
    private bool isGrounded;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float checkRadius;
    [SerializeField]
    public LayerMask whatIsGround;
    [SerializeField]
    public LayerMask cannon;

    [SerializeField]
    private float cooldownTime;

    [SerializeField]
    private bool speedcooldown;

  

[SerializeField]
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = defaultSpeed;
        speedcooldown = false;
        anim = GetComponent<Animator>();
    
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
          
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();           
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(transform.position.y < deathHeight)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(Physics2D.OverlapCircle(rb.transform.position, checkRadius, cannon))
        {
            rb.velocity = new Vector2(30, 10);
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        if (isGrounded){
           
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            
        }else{
          
            if(rb.velocity.x <= speed && rb.velocity.x >= -speed)
                rb.velocity += new Vector2(moveInput * speed, 0);         
        }
        if(Input.GetKey(KeyCode.D)   || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)  || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("isWalking", true);
        }
        else 
        {
            anim.SetBool("isWalking", false);
        }
        

        rb.velocity = new Vector2(Math.Min(Math.Max(rb.velocity.x, -speed), speed), rb.velocity.y);
    }

    public void ChangeSpeed(float newSpeed)
    {
        speed = newSpeed;
        if (!speedcooldown)
        {
            StartCoroutine(SpeedChangeCoolDown());
            speedcooldown = true;
        }
        
    }
    public void stop()
    {
        rb.velocity = new Vector2(0, 0);
        jumpForce = 0;
    }

    IEnumerator SpeedChangeCoolDown()
    {
        while(cooldownTime > 0)
        {
            cooldownTime -= Time.deltaTime;
            yield return null;
        }
        speed = defaultSpeed;
        yield return null;
    }

   
    




}
