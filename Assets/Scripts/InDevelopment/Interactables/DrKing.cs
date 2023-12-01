using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrKing : Interactable
{
    protected override void ActivateInteractable()
    {
        base.ActivateInteractable();
        UIData.Instance.AddLog("jameson's phone");
    }
}
