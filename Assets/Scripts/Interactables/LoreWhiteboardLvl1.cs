using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreWhiteboardLvl1 : Interactable
{
    protected override void ActivateInteractable()
    {
        base.ActivateInteractable();
        //Acquire Log
        UIData.Instance.AddLog("whiteboard");
        //Ensure log persists.
    }
}
