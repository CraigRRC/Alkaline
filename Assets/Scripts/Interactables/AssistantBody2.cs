using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssistantBody2 : Interactable
{
    protected override void ActivateInteractable()
    {
        base.ActivateInteractable();
        UIData.Instance.AddLog("keycard of dr.john");
        Activate();
    }
}
