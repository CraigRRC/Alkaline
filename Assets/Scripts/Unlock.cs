using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unlock : MonoBehaviour
{
    private bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activate()
    {
        active = true;
    }

    public void deactivate()
    {
        active = false;
    }
    public bool isActive()
    {
        return active;
    }
}
