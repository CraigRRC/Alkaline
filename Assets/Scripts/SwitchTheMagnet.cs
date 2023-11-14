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

    public Magnet[] magnets;

    private Animator switchAnimator;


    private void Awake()
    {
        switchAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       switchAnimator.enabled = true;

        if (magnets.Length <= 0) Debug.LogWarning("Nothing in Magnet array!!");

        if(switchedCount < maxSwitches)
        {
            for (int i = 0; i < magnets.Length; i++)
            {
                if (OnOff) 
                {
                    if (isOn)
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
            /*if (OnOff) Debug.Log("Magnet/s turned off");
            else Debug.Log("Magnet/s flipped");*/
            switchedCount++;
        }
        else Debug.Log("Hit max amount on switch");
    }

    private void Start()
    {
        if (magnets.Length <= 0) Debug.LogWarning("Nothing in Magnet array!!");
    }
}
