using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private BoxCollider2D boxCollider;
    public SpriteRenderer[] magnetVisual;
    private SpriteRenderer magnetColour;
    public LayerMask currentMask;
    public LayerMask tempMask;
    private Polarity cachedPolarity;

    public void Awake()
    {
        areaEffector = GetComponent<AreaEffector2D>();
        magnetColour = GetComponentInParent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        //Set Magnitude
        magnitude = 25000f;
        areaEffector.forceMagnitude = magnitude;
        currentMask = areaEffector.colliderMask;

    }

    //Set the layermask dynamically.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.gameObject.layer == 8)
        //{
        //    areaEffector.colliderMask = tempMask;
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //areaEffector.colliderMask = currentMask;
    }

    private void Update()
    {
        //Check polarity of magnet and act accordingly.
        switch (polarityState)
        {
            case Polarity.Positive:
                areaEffector.enabled = true;
                boxCollider.enabled = true;
                areaEffector.forceAngle = 90;
                areaEffector.forceMagnitude = magnitude;
                if(magnetVisual.Length > 0)
                {
                    for (int i = 0; i < magnetVisual.Length; i++)
                    {

                        magnetVisual[i].enabled = true;
                        magnetVisual[i].color = Color.red;
                        if (i != 0 && i != magnetVisual.Length - 1)
                        {
                            /*
                            Quaternion rotation = Quaternion.Euler(0f, 0f, 0f);
                            magnetVisual[i].transform.rotation = rotation;
                            */
                            // Fixes problems with situating magnets at an angle
                            magnetVisual[i].flipY = false;
                        }
                    }
                }
                if(magnetColour != null)
                {
                    magnetColour.color = Color.red;
                }
                
                break;
            case Polarity.Negative:
                areaEffector.enabled = true;
                boxCollider.enabled = true;
                areaEffector.forceAngle = -90;
                areaEffector.forceMagnitude = magnitude;
                if (magnetVisual.Length > 0)
                {
                    for (int i = 0; i < magnetVisual.Length; i++)
                    {

                        magnetVisual[i].enabled = true;
                        magnetVisual[i].color = Color.blue;
                        
                        if(i != 0 && i != magnetVisual.Length - 1)
                        {
                            /*
                            Quaternion rotation = Quaternion.Euler(0f, 0f, 180f);
                            magnetVisual[i].transform.rotation = rotation;\
                            */
                            magnetVisual[i].flipY = true;
                        }
                        
                    }
                }

                if (magnetColour != null)
                {
                    magnetColour.color = Color.blue;
                }
               
                break;
            case Polarity.Off:
                areaEffector.enabled = false;
                boxCollider.enabled = false;
                magnetColour.color = Color.black;
                if (magnetVisual.Length > 0)
                {
                    foreach (SpriteRenderer bar in magnetVisual)
                    {
                        bar.enabled = false;
                    }
                }
               
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

    public void TurnMagnetOff()
    {
        cachedPolarity = polarityState;
        polarityState = Polarity.Off;
    }

    public void TurnMagnetOn() { polarityState = cachedPolarity; }
}

//Enum that will control the flow of the magnet.
public enum Polarity
{
    Positive,
    Negative,
    Off
}