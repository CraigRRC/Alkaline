using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : Interactable
{
    public ComputerStation computerStation;
    protected override void ActivateInteractable()
    {
        base.ActivateInteractable();
        if (computerStation.HasKey())
        {
            UIData.Instance.AddLog("virus agis 0.9");
        }
    }
}
