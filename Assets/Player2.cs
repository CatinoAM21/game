using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




public class Player2 : MonoBehaviour
{
    public GameObject block;
    public GameObject blockPreview;
    private GameObject bP;
    void Start()
    {
        bP = Instantiate(blockPreview, new Vector3(0, 0, 11), transform.rotation);
    }
    void Update()
    {
        Vector3 v3 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        v3.x = (float)Math.Round((double)v3.x/3)*3; 
        v3.y = (float)Math.Round((double)v3.y/3)*3;
        if (Input.GetMouseButtonDown(0))
            Instantiate(block, v3, transform.rotation);
        bP.transform.position = v3;
    }
}
