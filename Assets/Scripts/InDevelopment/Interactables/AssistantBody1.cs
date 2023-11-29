using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssistantBody1 : Interactable
{
    protected override void ActivateInteractible()
    {
        base.ActivateInteractible();
        UIData.Instance.AddLog("keycard to hallway");
    }
}
