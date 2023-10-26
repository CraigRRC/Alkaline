using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    //State
    private Polarity polarityState;


    public void Awake()
    {
        //Default state
        polarityState = Polarity.Positive;
    }

    //One way we can do this, is with a box collider.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (polarityState == Polarity.Positive)
        {
            //Pull towards
        }
        else if (polarityState == Polarity.Negative)
        {
            //Push away
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