using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerController : MonoBehaviour
{
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
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isGrounded || Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {            
            rb.velocity = Vector2.up * jumpForce;            
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();           
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("WOrker");
        }
        if(transform.position.y < deathHeight)
        {
            SceneManager.LoadScene("WOrker");
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
        rb.velocity = new Vector2(Math.Min(Math.Max(rb.velocity.x, -speed), speed), rb.velocity.y);
    }

   
    




}
