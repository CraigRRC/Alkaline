using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrButter : Interactable
{
    protected override void ActivateInteractible()
    {
        base.ActivateInteractible();
        UIData.Instance.AddLog("virus agis 0.8");
    }
}
