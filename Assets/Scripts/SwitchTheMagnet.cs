using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTheMagnet : MonoBehaviour
{
    [Header("Switch them on to off or vise versa")]
    public bool OnOff;
    private bool isOn = true;

    //for only a certain amount of switches
    public int maxSwitches;
    private int switchedCount;

    //the magnets
    public Magnet[] magnets;

    [Header("Art of switch for animator")]
    public GameObject switchArt;
    private Animator switchAnimator;


    private void Awake()
    {
        switchAnimator = switchArt.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12) return;
        //play animation
        switchAnimator.SetTrigger("isActivated");

        //check if switch has magnets in magnet array
        if (magnets.Length <= 0) Debug.LogWarning("Nothing in Magnet array!!");

        //check if max amount of switches has been reached
        if(switchedCount < maxSwitches)
        {
            for (int i = 0; i < magnets.Length; i++)
            {
                if (OnOff) //check if it will be turning on/off the magnets
                {
                    if (magnets[i].polarityState != Polarity.Off) //check if teh magnets are on or not 
                    {
                        magnets[i].TurnMagnetOff();
                        isOn = false;
                        Debug.Log("Magnet/s turned off");
                    }
                    else
                    {
                        magnets[i].TurnMagnetOn();
                        isOn = true;
                        Debug.Log("Magnet/s turned on");
                    }
                } 
                else magnets[i].FlipPolarity();
                Debug.Log("Magnet/s flipped polarity");
            }
            switchedCount++;
        }
        else Debug.Log("Hit max amount on switch");
    }

    private void Start()
    {   //check if there is no magnets in the array at start
        if (magnets.Length <= 0) Debug.LogWarning("Nothing in Magnet array!!");
    }
}
