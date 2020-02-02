using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]

public class Cement : MonoBehaviour
{
    [SerializeField]
    private PlayerController pl;
    [SerializeField]
    private float newSpeed;

    [SerializeField]
    private AudioClip otherClip;




    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            pl = col.gameObject.GetComponent<PlayerController>();
            pl.ChangeSpeed(newSpeed);

            AudioSource audio = GetComponent<AudioSource>();

            audio.clip = otherClip;
            audio.Play();
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        pl = col.gameObject.GetComponent<PlayerController>();
        pl.ChangeSpeed(pl.defaultSpeed);
        GetComponent<AudioSource>().clip = otherClip;
        GetComponent<AudioSource>().Stop();
    }
}
