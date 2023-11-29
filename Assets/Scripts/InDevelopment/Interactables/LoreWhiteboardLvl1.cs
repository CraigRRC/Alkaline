using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreWhiteboardLvl1 : Interactable
{
    protected override void ActivateInteractible()
    {
        base.ActivateInteractible();
        //Acquire Log
        UIData.Instance.AddLog("whiteboard");
        //Ensure log persists.
    }
}
