using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(AudioSource))]

public class victoryZone : MonoBehaviour
{
    [SerializeField]
    private AudioClip otherClip;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {


            AudioSource audio = GetComponent<AudioSource>();

            audio.clip = otherClip;
            audio.Play();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Invoke("loadNextScene", 0.2f);
        }
    }

    void loadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
