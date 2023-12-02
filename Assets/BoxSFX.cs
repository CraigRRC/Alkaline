using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BoxSFX : MonoBehaviour
{

    [Header("Box Clang")]
    public bool soundOn = true;
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
           if(collision.relativeVelocity.magnitude > 2f)
            {
               if(soundOn)
                audioSource.Play(); 
            }
        }
    }


}
