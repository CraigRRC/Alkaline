using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlStation : Interactable
{
    public GameObject screen;

    protected override void Awake()
    {
        base.Awake();
        if (screen != null )
            screen.SetActive(false);
    }

    protected override void ActivateInteractable()
    {
        base.ActivateInteractable();
        if (screen != null)
            screen.SetActive(true);
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
        if(screen != null)
            screen.SetActive(false);
    }



}
