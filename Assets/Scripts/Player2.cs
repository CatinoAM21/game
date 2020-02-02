using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




public class Player2 : MonoBehaviour
{
    public GameObject block;
    public GameObject bP;
    public GameObject gurder;
    public GameObject gP;
    public GameObject cannon;
    public GameObject cP;
    private GameObject preview;
    private bool placementAllowed = false;
    public int amountRemaining;
    private int blockType = 0;

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

    void Start()
    {
        preview = Instantiate(bP, new Vector3(0, 0, 0), transform.rotation);
    }
    void Update()
    {        
        Vector3 v3 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        v3.x = (float)Math.Round((double)v3.x); 
        v3.y = (float)Math.Round((double)v3.y);
        placementAllowed = (!Physics2D.OverlapCircle(v3, checkRadius, whatIsGround) && !Physics2D.OverlapCircle(v3, checkRadius, whatIsPlayer));
        if (Input.GetMouseButtonDown(1))
        {
            if (blockType == 0){
                Destroy(preview);
                preview = Instantiate(gP, v3, transform.rotation);
                blockType = 1;
                tmp.UpdateScore(amountRemaining, "Gurder", 2);
            }                
            else if(blockType == 1){
                Destroy(preview);
                preview = Instantiate(cP, v3, transform.rotation);
                blockType = 2;
                tmp.UpdateScore(amountRemaining, "Cannon", 5);
            }
            else if(blockType == 2){
                Destroy(preview);
                preview = Instantiate(bP, v3, transform.rotation);
                blockType = 0;
                tmp.UpdateScore(amountRemaining, "Block", 1);
            }
        } 
        if (Input.GetMouseButtonDown(0) && placementAllowed && amountRemaining > 0){
            if(blockType == 0){
                Instantiate(block, v3, transform.rotation);
                amountRemaining--;
                tmp.UpdateScore(amountRemaining, "Block", 1);
            }
            else if(blockType == 1 && amountRemaining >1 ){
                Instantiate(gurder, v3, transform.rotation);
                amountRemaining-=2;
                tmp.UpdateScore(amountRemaining, "Gurder", 2);
            }else if(blockType == 3 && amountRemaining > 4)
            {
                Instantiate(cannon, v3, transform.rotation);
                amountRemaining -= 4;
                tmp.UpdateScore(amountRemaining, "Cannon", 2);
            }
            
        }
        preview.transform.position = v3;
    }
}
