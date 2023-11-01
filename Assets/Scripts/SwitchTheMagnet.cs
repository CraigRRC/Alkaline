using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTheMagnet : MonoBehaviour
{
    [Header("Switch them on to off or vise versa?")]
    public bool OnToOff;

    //for only a certain amount of switches
    public int maxSwitches;
    private int switchedCount;

    public Magnet[] magnets;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (magnets.Length <= 0) Debug.LogWarning("Nothing in Magnet array!!");

        if(switchedCount < maxSwitches)
        {
            for (int i = 0; i < magnets.Length; i++)
            {
                if (OnToOff) magnets[i].TurnMagnetOff();
                else magnets[i].FlipPolarity();
            }

            if (OnToOff) Debug.Log("Magnet/s turned off");
            else Debug.Log("Magnet/s flipped");
            switchedCount++;
        }
        else Debug.Log("Hit max amount on switch");
    }

    private void Start()
    {
        if (magnets.Length <= 0) Debug.LogWarning("Nothing in Magnet array!!");
    }
}
