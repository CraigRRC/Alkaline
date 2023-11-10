using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public BoxCollider2D doorCollider;
    public ButtonType buttonType;

    private void Awake()
    {
        if(doorCollider != null)
        {
            doorCollider.enabled = false;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7) return;
        
        if (doorCollider != null)
        {
            doorCollider.enabled = true;
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7) return;

        if (doorCollider != null)
        {
            doorCollider.enabled = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (doorCollider != null && buttonType == ButtonType.Hold)
        {
            doorCollider.enabled = false;
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
