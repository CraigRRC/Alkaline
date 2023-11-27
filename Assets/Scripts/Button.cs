using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Unlock
{
    //public BoxCollider2D doorCollider;
    public ButtonType buttonType;
    public ButtonState buttonState;
    private Animator buttonAnimator;
    private BoxCollider2D buttonCollider;

    private void Awake()
    {
        /*
        if(doorCollider != null)
        {
            doorCollider.enabled = false;
        }
        */
        buttonAnimator = GetComponent<Animator>();
        buttonCollider = GetComponentInChildren<BoxCollider2D>();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7) return;

        if (collision.otherCollider.name == "ButtonHitBox")
        {
            /*
            if (doorCollider != null)
            {
                doorCollider.enabled = true;
            }
            */
            Activate();
            buttonAnimator.SetBool("IsButtonDown", true);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.otherCollider.name == "ButtonHitBox")
        {
            /*
            if (doorCollider != null)
            {
                doorCollider.enabled = true;
            }
            */
            Activate();
            //New anaimation to hold the last keyframe
            //buttonAnimator.SetBool("IsButtonDown", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.otherCollider.name == "ButtonHitBox")
        {
            
            if (buttonType == ButtonType.Hold)
            {
                Deactivate();
                buttonAnimator.SetBool("IsButtonDown", false);
            }
           
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
       
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
