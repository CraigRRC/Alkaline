using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrKing : Interactable
{
    protected override void Activate()
    {
        base.Activate();
        UIData.Instance.AddLog("jameson's phone");
    }
}
