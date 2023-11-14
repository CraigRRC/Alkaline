using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : Unlock
{
    public BoxCollider2D doorCollider;
    private Animator plateAnimator;
    private BoxCollider2D plateCollider;
    private BoxCollider2D plateDetector;
    private Transform activeCheck;
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
        plateAnimator = GetComponentInChildren<Animator>();
        plateCollider = GetComponent<BoxCollider2D>();
        activeCheck = this.gameObject.transform.GetChild(0);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (IsOn())
        {
            Activate();
        }
        else
        {
            Deactivate();
        }
    }

    private bool IsOn()
    {
        return Physics2D.OverlapCircle(activeCheck.position, 0.01f, activeLayer);
    }
}
