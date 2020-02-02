using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEnterTrigger : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.isKinematic = false;
          }
       
    }
}
