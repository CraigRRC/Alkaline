using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkstationKeycard : Interactable
{
    protected override void ActivateInteractable()
    {
        base.ActivateInteractable();
        UIData.Instance.AddLog("keycard to work station");
        Activate();
    }
}
