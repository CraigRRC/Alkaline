using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story3Cabinet : Interactable
{
    public DoorState doorState;
    public Sprite doorOpen;
    public SpriteRenderer doorRenderer;

    public enum DoorState
    {
        open,
        closed,
        dontinteract,
    }

    protected override void ActivateInteractible()
    {
        base.ActivateInteractible();

        switch (doorState)
        {
            case DoorState.open:
                UIData.Instance.AddLog("virus agis 0.5");
                UIData.Instance.AddLog("virus agis 1.2");
                break;
            case DoorState.closed:
                doorState = DoorState.open;
                doorRenderer.sprite = doorOpen;
                break;
            case DoorState.dontinteract:
                break;


        }
    }
}
