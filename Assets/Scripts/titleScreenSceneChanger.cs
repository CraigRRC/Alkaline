using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleScreenSceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadScene(string Level_0)
    {
        SceneManager.LoadScene(Level_0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
