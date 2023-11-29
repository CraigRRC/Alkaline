using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusanPhone : Interactable
{
    protected override void ActivateInteractible()
    {
        base.ActivateInteractible();
        UIData.Instance.AddLog("susan's phone");
    }
}
