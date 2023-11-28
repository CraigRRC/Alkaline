using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssistantBody2 : Interactable
{
    protected override void Activate()
    {
        base.Activate();
        UIData.Instance.AddLog("keycard of dr.john");
    }
}
