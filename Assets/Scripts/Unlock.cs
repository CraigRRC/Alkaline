using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    static bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void activate()
    {
        active = true;
    }

    public static void deactivate()
    {
        active = false;
    }
    public bool isActive()
    {
        return active;
    }
}
