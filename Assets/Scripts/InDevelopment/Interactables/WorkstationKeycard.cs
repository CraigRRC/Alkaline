using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkstationKeycard : Interactable
{
    protected override void ActivateInteractible()
    {
        base.ActivateInteractible();
        UIData.Instance.AddLog("keycard to work station");
    }
}
