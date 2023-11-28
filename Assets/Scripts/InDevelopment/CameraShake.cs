using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

//Shake camera when a box collides with the ground.
//Can be turned on or off per level/options menu.
public class CameraShake : MonoBehaviour
{
    public Camera cam;
    private bool isShaking;

     /*if (collision.relativeVelocity.magnitude > lethalImpactForce)
        {
            PlayerDead();
        }*/

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShakeCam(float ShakeDuration)
    {
        isShaking = true;

    }
}
