using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssistantBody2 : Interactable
{
    protected override void ActivateInteractable()
    {
        base.ActivateInteractable();
        UIData.Instance.AddLog("dr. buttoworth john's keycard");
        Activate();
    }
}
