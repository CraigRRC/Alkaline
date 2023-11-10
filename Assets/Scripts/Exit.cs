using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Class that will be placed on the exit door in the room.
public class Exit : MonoBehaviour
{
    private BoxCollider2D doorCollider;
    private Animator doorAnimator;
    //Needs to be refactored to not be manual.
    public int sceneIndex;
   
    private void Awake()
    {
        doorCollider = GetComponent<BoxCollider2D>();
        doorAnimator = GetComponent<Animator>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 11)
        {
            //first play animation, then load scene.
            SceneManager.LoadScene(sceneIndex);
            
        }
    }


}
