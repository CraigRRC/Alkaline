using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusanPhone : Interactable
{
    protected override void Activate()
    {
        base.Activate();
        UIData.Instance.AddLog("susan's phone");
    }
}
