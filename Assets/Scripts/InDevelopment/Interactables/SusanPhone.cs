using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusanPhone : Interactable
{
    protected override void ActivateInteractable()
    {
        base.ActivateInteractable();
        UIData.Instance.AddLog("susan's phone");
    }
}
