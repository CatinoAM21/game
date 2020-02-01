using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




public class Player2 : MonoBehaviour
{
    public GameObject block;
    public GameObject bP;
    private bool placementAllowed = false;
    public int amountRemaining;

    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float checkRadius;
    [SerializeField]
    public LayerMask whatIsGround;

    void Start()
    {
        amountRemaining = 4;
    }
    void Update()
    {
        placementAllowed = !Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        Vector3 v3 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        v3.x = (float)Math.Round((double)v3.x); 
        v3.y = (float)Math.Round((double)v3.y);
        if (Input.GetMouseButtonDown(0) && placementAllowed && amountRemaining > 0)
        {
            Instantiate(block, v3, transform.rotation);
            amountRemaining--;
        }            
        bP.transform.position = v3;
    }
}
