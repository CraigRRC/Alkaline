using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : Interactable
{
    public ComputerStation computerStation;
    protected override void ActivateInteractible()
    {
        base.ActivateInteractible();
        if (computerStation.HasKey())
        {
            UIData.Instance.AddLog("virus agis 0.9");
        }
    }
}
