using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrKing : Interactable
{
    protected override void ActivateInteractible()
    {
        base.ActivateInteractible();
        UIData.Instance.AddLog("jameson's phone");
    }
}
