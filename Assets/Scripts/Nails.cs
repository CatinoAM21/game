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


    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player"))
        {
            
            AudioSource audio = GetComponent<AudioSource>();

            audio.clip = otherClip;
            audio.Play();


            Invoke("loadScene", 0.2f);
            
        }
    }

 

    void loadScene()
    {
        SceneManager.LoadScene("WOrker");
    }
}
