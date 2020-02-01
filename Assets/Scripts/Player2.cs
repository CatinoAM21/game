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
    private blocks tmp;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float checkRadius;
    [SerializeField]
    public LayerMask whatIsGround;
    [SerializeField]
    public LayerMask whatIsPlayer;
    [SerializeField]
    private Transform playerCheck;

    void Start()
    {
        amountRemaining = 4;
    }
    void Update()
    {
        placementAllowed = (!Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround) && !Physics2D.OverlapCircle(playerCheck.position, checkRadius, whatIsPlayer));
        Vector3 v3 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        v3.x = (float)Math.Round((double)v3.x); 
        v3.y = (float)Math.Round((double)v3.y);
        if (Input.GetMouseButtonDown(0) && placementAllowed && amountRemaining > 0)
        {
            Instantiate(block, v3, transform.rotation);
            amountRemaining--;
            tmp.UpdateScore(amountRemaining);
        }            
        bP.transform.position = v3;
    }
}
