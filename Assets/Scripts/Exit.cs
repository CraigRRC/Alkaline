using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Class that will be placed on the exit door in the room.
public class Exit : MonoBehaviour
{
    private BoxCollider2D doorCollider;
    //This is temporary until the animation comes in.
    private SpriteRenderer spriteRenderer;
    //Needs to be refactored to not be manual.
    public int sceneIndex;
    private void Awake()
    {
        doorCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        doorCollider.enabled = !spriteRenderer.enabled;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            //first play animation, then load scene.
            SceneManager.LoadScene(sceneIndex);
            
        }
    }


}
