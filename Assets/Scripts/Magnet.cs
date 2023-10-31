using System.Collections;
using System.Collections.Generic;
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

    public void Awake()
    {
        //Default state
        polarityState = Polarity.Positive;
        areaEffector = GetComponent<AreaEffector2D>();
        //Set Magnitude
        magnitude = 40000;
        areaEffector.forceMagnitude = magnitude;
    }

    private void Update()
    {
        //Check polarity of magnet and act accordingly.
        switch (polarityState)
        {
            case Polarity.Positive:
                areaEffector.forceAngle = 90;
                areaEffector.forceMagnitude = magnitude;
                break;
            case Polarity.Negative:
                areaEffector.forceAngle = -90;
                areaEffector.forceMagnitude = magnitude;
                break;
            case Polarity.Off:
                areaEffector.forceMagnitude = 0;
                break;
            default:
                break;
        }
    }

    //Ability to set the polarity from outside the class.
    //Potentially used by the player to be able to switch the polarity,
    //Or, maybe a switch in the world. Or both!
    public void SetPolarity(Polarity polarity) { polarityState = polarity; }

}

//Enum that will control the flow of the magnet.
public enum Polarity
{
    Positive,
    Negative,
    Off
}