using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 horizonalInput = Vector2.zero;
    //public to debug
    public float playerSpeed = 500f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Just left and right movement for now?? not sure.
        horizonalInput = new Vector2(Input.GetAxis("Horizontal"), 0f);
    }

    private void FixedUpdate()
    {
        //Processing the horizontal movement.
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            rb.AddForce(horizonalInput * playerSpeed * Time.deltaTime);
        }
    }
}
