using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class ChargeStation : Interactable
{
    private Animator animator;
    public ChargingStationState chargingState;
    
    public enum ChargingStationState
    {
        charge,
        levelOne,
        levelTwo,
        levelThree,
        levelFour,
        levelFive,
        levelSix,
        levelSeven,
    }

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }

    protected override void Activate()
    {
        base.Activate();
        //Play charging animation
        if (animator != null)
        {
            animator.SetTrigger("Charge");
        }
        //Increase number of battery cells in hud.
        if(UIData.Instance != null && chargingState == ChargingStationState.charge)
        {
            UIData.Instance.ChargeBattery();
        }

        switch (chargingState)
        {
            case ChargingStationState.levelOne:
                UIData.Instance.AddLog("robot protocol 001");
                break;
            case ChargingStationState.levelTwo:
                UIData.Instance.AddLog("robot protocol 002");
                break;
            case ChargingStationState.levelThree:
                UIData.Instance.AddLog("robot protocol 003");
                break;


        }
    }
}

