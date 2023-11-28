using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreWhiteboardLvl1 : Interactable
{
    protected override void Activate()
    {
        base.Activate();
        //Acquire Log
        UIData.Instance.AddLog("whiteboard");
        //Ensure log persists.
    }
}
