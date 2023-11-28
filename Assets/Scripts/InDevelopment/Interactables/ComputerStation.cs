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
    }
    protected override void Activate()
    {
        base.Activate();
        if(state == ComputerState.levelOne)
        {
            UIData.Instance.AddLog("keycard to general area");
        }

    }
}
