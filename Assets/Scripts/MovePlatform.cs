using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            rb.gravityScale = 0;
            rb.drag = 0;
            rb.freezeRotation = true;
            
        }
    }

    private void FixedUpdate()
    {
        if (rb == null) return;
        
       
    }
}
