using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : Unlock
{
    private Animator plateAnimator;
    private BoxCollider2D plateCollider;
    private BoxCollider2D plateDetector;
    private Transform activeCheck;
    private SpriteRenderer plateButton;
    private SpringJoint2D plateSpring;
    private Rigidbody2D rb;
    [SerializeField] LayerMask activeLayer;

    // Start is called before the first frame update
    private void Awake()
    {
        /*
        if (doorCollider != null)
        {
            doorCollider.enabled = false;
        }
        */
        plateSpring = GetComponentInChildren<SpringJoint2D>();
        plateButton = this.transform.GetChild(1).GetComponent<SpriteRenderer>();
        plateAnimator = GetComponentInChildren<Animator>();
        plateCollider = GetComponent<BoxCollider2D>();
        rb = GetComponentInChildren<Rigidbody2D>();
        activeCheck = this.gameObject.transform.GetChild(0);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (IsOn())
        {
            Activate();
            plateAnimator.SetBool("IsPressingDown", true);

        }
        else
        {
            Deactivate();
            plateAnimator.SetBool("IsPressingDown", false);
        }
        if (!plateSpring.isActiveAndEnabled)
        {
            plateAnimator.SetBool("IsPressBroken", true);
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        } 
    }

    private bool IsOn()
    {
        return Physics2D.OverlapCircle(activeCheck.position, 0.01f, activeLayer);
    }
}
