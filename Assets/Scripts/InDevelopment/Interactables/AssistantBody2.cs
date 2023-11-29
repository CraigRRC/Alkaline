using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssistantBody2 : Interactable
{
    protected override void ActivateInteractible()
    {
        base.ActivateInteractible();
        UIData.Instance.AddLog("keycard of dr.john");
        Activate();
    }
}
