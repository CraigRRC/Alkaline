using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Button : Unlock
{
    //public BoxCollider2D doorCollider;
    public ButtonType buttonType;
    public ButtonState buttonState;
    private Animator buttonAnimator;
    private BoxCollider2D buttonCollider;
    private AudioSource buttonAudioSource;

    private void Awake()
    {
        buttonAudioSource = GetComponent<AudioSource>();
        buttonAudioSource.playOnAwake = false;
        buttonAnimator = GetComponent<Animator>();
        buttonCollider = GetComponentInChildren<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7) return;

        if (collision.otherCollider.name == "ButtonHitBox")
        {
            if (!buttonAudioSource.isPlaying)
            {
                buttonAudioSource.Play();
            }
            Activate();
            buttonAnimator.SetBool("IsButtonDown", true);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.otherCollider.name == "ButtonHitBox")
        {
            Activate();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.otherCollider.name == "ButtonHitBox")
        {

            if (!buttonAudioSource.isPlaying)
            {
                buttonAudioSource.Play();
            }

            if (buttonType == ButtonType.Hold)
            {
                
                Deactivate();
                buttonAnimator.SetBool("IsButtonDown", false);
            }  
        }
    }
}

public enum ButtonType
{
    OnePress,
    Hold,
}

public enum ButtonState
{
    Standby,
    Activated,
}
