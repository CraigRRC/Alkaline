using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent (typeof(AudioSource))]
//Potentally a parent class for all interactable objects in the story maps.
//Base functionality:
//1) On trigger enter
//2) F sprite appears above player.
//3) If player is standing in the trigger and presses F. Do something.
//Do something will be different for each interactable, therefore might be a good idea to make child classes.
public abstract class Interactable : Unlock
{

    private BoxCollider2D trigger;
    public bool inTrigger;
    public bool doOnce;
    private AudioSource audioSource;

    protected virtual void Awake()
    {
        trigger = GetComponent<BoxCollider2D>();
        trigger.isTrigger = true;
        doOnce = true;
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        //Player
        if (collision.gameObject.layer == 11)
        {
            inTrigger = true;
        }
    }

    protected virtual void Update()
    {
        if (doOnce && inTrigger && Input.GetKey(KeyCode.F))
        {
            ActivateInteractible();
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        //Player
        if (collision.gameObject.layer == 11)
        {
            inTrigger = false;
        }
    }


    protected virtual void ActivateInteractible()
    {
        doOnce = false;
        audioSource.Play();
        StartCoroutine(CanInteract());
    }

    private IEnumerator CanInteract()
    {
        yield return new WaitForSeconds(1);
        doOnce = true;
    }
}