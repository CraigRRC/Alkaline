using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderConverter : MonoBehaviour
{
    // Start is called before the first frame update
    

    private void Awake()
    {
        Shader newShader = Shader.Find("Universal Render Pipeline/2D/Sprite-Lit-Default");
        


        if (newShader == null)
            Debug.Log("Shader is null!");
        else
            GetComponent<Renderer>().sharedMaterial.shader = newShader;
    }
    
}
