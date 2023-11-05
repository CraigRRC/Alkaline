using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(AreaEffector2D))]

/* AreaEffector2D Implementation
 * 
 * []Require boxCollider2D
 * []Require areaEffector2D
 * []Set a magnitude variable for amount of force to be applied
 * []Set forceTarget to rigidBody
 * []Apply forces
 * 
 * OPTIONAL
 * []Apply Drag
 * []Other fun features
 * 
 */

public class Magnet : MonoBehaviour
{
    //State
    public Polarity polarityState;
    private float magnitude;
    private AreaEffector2D areaEffector;
    private SpriteRenderer magetVisual;
    private SpriteRenderer magnetColour;
    public LayerMask currentMask;
    public LayerMask tempMask;

  

    public void Awake()
    {
        areaEffector = GetComponent<AreaEffector2D>();
        magetVisual = GetComponentInChildren<SpriteRenderer>();
        magnetColour = GetComponentInParent<SpriteRenderer>();
        //Set Magnitude
        magnitude = 25000f;
        areaEffector.forceMagnitude = magnitude;
        currentMask = areaEffector.colliderMask;
    }

    //Set the layermask dynamically.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            areaEffector.colliderMask = tempMask;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        areaEffector.colliderMask = currentMask;
    }

    private void Update()
    {
        //Check polarity of magnet and act accordingly.
        switch (polarityState)
        {
            case Polarity.Positive:
                areaEffector.forceAngle = 90;
                areaEffector.forceMagnitude = magnitude;
                if(magnetColour != null)
                {
                    magnetColour.color = Color.red;
                }
                magetVisual.enabled = true;
                break;
            case Polarity.Negative:
                areaEffector.forceAngle = -90;
                areaEffector.forceMagnitude = magnitude;
                if (magnetColour != null)
                {
                    magnetColour.color = Color.blue;
                }
                magetVisual.enabled = true;
                break;
            case Polarity.Off:
                areaEffector.forceMagnitude = 0;
                magnetColour.color = Color.black;
                magetVisual.enabled = false;
                break;
            default:
                break;
        }
    }

    //Ability to set the polarity from outside the class.
    //Potentially used by the player to be able to switch the polarity,
    //Or, maybe a switch in the world. Or both!
    public void SetPolarity(Polarity polarity) { polarityState = polarity; }

    public void FlipPolarity()
    {
        switch (polarityState)
        {
            case Polarity.Positive:
                polarityState = Polarity.Negative;
                break;
            case Polarity.Negative:
                polarityState = Polarity.Positive;
                break;
            default:
                break;
        }
    }

    public void TurnMagnetOff() { polarityState = Polarity.Off; }
}

//Enum that will control the flow of the magnet.
public enum Polarity
{
    Positive,
    Negative,
    Off
}