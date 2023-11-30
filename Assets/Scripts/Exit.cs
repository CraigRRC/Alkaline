using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Class that will be placed on the exit door in the room.
public class Exit : MonoBehaviour
{
    private BoxCollider2D doorCollider;
    private Animator doorAnimator;
    private bool safeToMoveToNextLevel = false;
    private AudioSource audioSource;
   
    private void Awake()
    {
        doorCollider = GetComponent<BoxCollider2D>();
        doorAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //if door is open, enable the collider.
        if (doorCollider.enabled)
        {
            doorAnimator.SetBool("DoorOpen", true);
        }
        else
        {
            doorAnimator.SetBool("DoorOpen", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            //first play animation, then load scene.
            if (safeToMoveToNextLevel)
            {
                int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
                SceneManager.LoadScene(nextScene);
            }

        }
    }

    //Callback function for the door opening animation.
    public void MoveToNextLevel()
    {
        safeToMoveToNextLevel = true;
    }

    public void DoorSound()
    {
        audioSource.Play();
    }

}
