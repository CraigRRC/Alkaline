using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkstationKeycard : Interactable
{
    protected override void Activate()
    {
        base.Activate();
        UIData.Instance.AddLog("keycard to work station");
    }
}
