using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrButter : Interactable
{
    protected override void Activate()
    {
        base.Activate();
        UIData.Instance.AddLog("virus agis 0.8");
    }
}
