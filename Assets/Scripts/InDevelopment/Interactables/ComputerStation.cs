using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerStation : Interactable
{
    public ComputerState state;

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
    protected override void Activate()
    {
        base.Activate();
        switch (state)
        {
            case ComputerState.levelOne:
                UIData.Instance.AddLog("keycard to general area");
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
                break;
            case ComputerState.levelSix:
                break;
            case ComputerState.levelSeven:
                break;
            case ComputerState.DontInteract: 
                break;

        }
           
        

    }
}
