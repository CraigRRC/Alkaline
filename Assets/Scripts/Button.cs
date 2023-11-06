using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public SpriteRenderer door;
    public ButtonType buttonType;

    private void Awake()
    {
        door.color = Color.red;
        Debug.Log("here?");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7) return;
        
        if (door != null)
        {
            door.color = Color.black;
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7) return;

        if (door != null)
        {
            door.color = Color.black;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (door != null && buttonType == ButtonType.Hold)
        {
            door.color = Color.red;
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
