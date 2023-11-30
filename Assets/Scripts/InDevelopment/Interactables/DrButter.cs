using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrButter : Interactable
{
    protected override void ActivateInteractable()
    {
        base.ActivateInteractable();
        UIData.Instance.AddLog("virus agis 0.8");
    }
}
