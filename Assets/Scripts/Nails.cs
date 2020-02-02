using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System;

[RequireComponent(typeof(AudioSource))]


public class Nails : MonoBehaviour
{
   
    [SerializeField]
    private AudioClip otherClip;
    [SerializeField]
    private PlayerController pl;
    [SerializeField]
    private float newSpeed;


    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player"))
        {
            
            AudioSource audio = GetComponent<AudioSource>();

            audio.clip = otherClip;
            audio.Play();
            pl = col.gameObject.GetComponent<PlayerController>();
            pl.ChangeSpeed(newSpeed);
            pl.stop();
            Invoke("loadScene", 1f);
            
        }
    }

 

    void loadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
