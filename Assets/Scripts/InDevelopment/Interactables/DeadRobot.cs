using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadRobot : Interactable
{
    protected override void ActivateInteractable()
    {
        base.ActivateInteractable();

        UIData.Instance.AddLog("keycard to lab");
        Activate();
    }
}
