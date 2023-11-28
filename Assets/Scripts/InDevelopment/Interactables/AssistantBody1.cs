using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssistantBody1 : Interactable
{
    protected override void Activate()
    {
        base.Activate();
        UIData.Instance.AddLog("keycard to hallway");
    }
}
