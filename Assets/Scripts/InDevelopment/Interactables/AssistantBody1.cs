using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssistantBody1 : Interactable
{
    protected override void ActivateInteractable()
    {
        base.ActivateInteractable();
        UIData.Instance.AddLog("keycard to hallway");
        Activate();
    }
}
