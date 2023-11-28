using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : Interactable
{
    public ComputerStation computerStation;
    protected override void Activate()
    {
        base.Activate();
        if (computerStation.hasLockerKey)
        {
            UIData.Instance.AddLog("virus agis 0.9");
        }
    }
}
