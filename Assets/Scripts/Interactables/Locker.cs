using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : Interactable
{
    public ComputerStation computerStation;
    public DoorState doorState;
    public Sprite doorOpen;
    private SpriteRenderer doorRenderer;
    private AudioSource doorSound;
    public AudioClip doorCreek;
    public AudioClip uiBlip;

    protected override void Awake()
    {
        base.Awake();
        doorSound = GetComponent<AudioSource>();
        doorRenderer = GetComponent<SpriteRenderer>();
    }

    public enum DoorState
    {
        open,
        closed,
        dontinteract,
    }

    protected override void ActivateInteractable()
    {
        if (!computerStation.HasKey()) return;
        switch (doorState)
        {
            case DoorState.open:
                doorSound.clip = uiBlip;
                UIData.Instance.AddLog("virus agis 0.9");
                break;
            case DoorState.closed:
                doorSound.clip = doorCreek;
                doorState = DoorState.open;
                doorRenderer.sprite = doorOpen;
                break;
            case DoorState.dontinteract:
                break;


        }

        base.ActivateInteractable();
    }
    //protected override void ActivateInteractable()
    //{
    //    base.ActivateInteractable();
    //    if (computerStation.HasKey())
    //    {
    //        
    //    }
    //}
}
