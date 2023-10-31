using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public SpriteRenderer door;
    public BoxCollider2D baseCollider;
    public ButtonType buttonType;
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        baseCollider.enabled = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        baseCollider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        door.enabled = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(buttonType == ButtonType.Hold)
        {
            door.enabled = true;
        }
       
    }
}

public enum ButtonType
{
    OnePress,
    Hold,
}
