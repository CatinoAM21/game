using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Player2 : MonoBehaviour
{
    public GameObject block;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 v3 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            Instantiate(block, v3, transform.rotation);
        }        
    }
}
