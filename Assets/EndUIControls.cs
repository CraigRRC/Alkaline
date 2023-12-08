using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndUIControls: MonoBehaviour
{
    public void PlayBonus()
    {
        SceneManager.LoadScene("Level_61");
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
