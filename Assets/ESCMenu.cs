using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESCMenu : MonoBehaviour
{
    public void MainMenu()
    {
        Time.timeScale = 1f;
        Destroy(FindObjectOfType<BGM>().gameObject);
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
        
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
