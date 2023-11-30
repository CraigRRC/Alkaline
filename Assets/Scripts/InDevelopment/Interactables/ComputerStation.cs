using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerStation : Interactable
{
    public ComputerState state;
    private bool hasLockerKey = false;

    public enum ComputerState
    {
        levelOne,
        levelTwo,
        levelThree,
        levelFour,
        levelFive,
        levelSix,
        levelSeven,
        DontInteract,
    }
    protected override void ActivateInteractable()
    {
        base.ActivateInteractable();
        switch (state)
        {
            case ComputerState.levelOne:
                UIData.Instance.AddLog("keycard to general area");
                Activate();
                break;
            case ComputerState.levelTwo:
                UIData.Instance.AddLog("computer screen");
                break;
            case ComputerState.levelThree:
                break;
            case ComputerState.levelFour:
                UIData.Instance.AddLog("joe's video");
                break;
            case ComputerState.levelFive:
                UIData.Instance.AddLog("key of susan's locker");
                hasLockerKey = true;
                break;
            case ComputerState.levelSix:
                UIData.Instance.AddLog("butter's computer log");
                Activate();
                break;
            case ComputerState.levelSeven:
                break;
            case ComputerState.DontInteract: 
                break;
        }
    }

    public bool HasKey() { return hasLockerKey; }

}

