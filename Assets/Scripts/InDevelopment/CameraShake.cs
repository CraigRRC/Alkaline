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
    private Vector2 origonalCamPos;
    public float impactForce = 2f;
    private bool isShaking;
    public bool canShake = true;
    public float shakeDuration = 1.0f;
    private float elapsedTime  = 0.0f;

     /*if (collision.relativeVelocity.magnitude > lethalImpactForce)
        {
            PlayerDead();
        }*/



    // Start is called before the first frame update
    void Start()
    {
        if(cam == null)
        {
            Debug.Log("No cam to shake");
            canShake = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(canShake && collision.relativeVelocity.magnitude > impactForce && isShaking == false)
        {
            ShakeCam(shakeDuration);
        }
    }

    void ShakeCam(float shakeDuration)
    {
        origonalCamPos = cam.transform.position;
        isShaking = true;

        while (elapsedTime < shakeDuration)
        {
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);                                //CURRENTLY EXTREEEEEEEMLY BROKEN DO NOT USE (yet)
            transform.position = new Vector2(x, y/*, origonalCamPos.z*/);
        }

        transform.position = origonalCamPos;
    }
}
