using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeStation : Interactable
{
    private Animator animator;
    public ChargingStationState chargingState;
    private AudioSource audioSource;
    public AudioClip batteryCharge;
    
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
        audioSource = GetComponent<AudioSource>();
    }

    protected override void ActivateInteractable()
    {
        base.ActivateInteractable();
        //Play charging animation
        if (animator != null)
        {
            animator.SetTrigger("Charge");
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
            case ChargingStationState.levelFour:
                UIData.Instance.AddLog("robot protocol 004");
                break;
            case ChargingStationState.levelFive:
                UIData.Instance.AddLog("robot protocol 005");
                break;
            case ChargingStationState.levelSix:
                UIData.Instance.AddLog("robot protocol 006");
                break;
            case ChargingStationState.levelSeven:
                UIData.Instance.AddLog("robot protocol 006 activating");
                break;
            case ChargingStationState.charge:
                audioSource.clip = batteryCharge;
                audioSource.Play();
                UIData.Instance.ChargeBattery();
                break;


        }
    }
}

