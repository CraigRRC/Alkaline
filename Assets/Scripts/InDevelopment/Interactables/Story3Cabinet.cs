using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story3Cabinet : Interactable
{
    public DoorState doorState;
    public Sprite doorOpen;
    public SpriteRenderer doorRenderer;
    private AudioSource doorSound;
    public AudioClip doorCreek;
    public AudioClip uiBlip;

    protected override void Awake()
    {
        base.Awake();
        doorSound = GetComponent<AudioSource>();
    }

    public enum DoorState
    {
        open,
        closed,
        dontinteract,
    }

    protected override void ActivateInteractable()
    {
        

        switch (doorState)
        {
            case DoorState.open:
                doorSound.clip = uiBlip;
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

        base.ActivateInteractable();
    }
}
