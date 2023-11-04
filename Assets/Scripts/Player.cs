using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Magnet[] magnetsInLvl;

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (magnetsInLvl != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                foreach (var magnet in magnetsInLvl)
                {
                    magnet.FlipPolarity();
                }
               
            }
        }
        
    }
}
