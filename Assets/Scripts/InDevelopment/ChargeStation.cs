using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class ChargeStation : Interactable
{
    private Animator animator;

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }

    protected override void Activate()
    {
        base.Activate();
        //Play charging animation
        if (animator != null)
        {
            animator.SetTrigger("Charge");
        }
        //Increase number of battery cells in hud.
        if(UIData.Instance != null)
        {
            UIData.Instance.ChargeBattery();
        }
    }
}

