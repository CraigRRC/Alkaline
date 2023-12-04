using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiscControls : MonoBehaviour
{
    private GameObject escMenu;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        escMenu = GetComponentInChildren<Canvas>().gameObject;
        if (escMenu != null )
            escMenu.SetActive(false);
    }

    public void Restart()
    {
        Destroy(this.gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(this.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (escMenu == null) return;
            if (escMenu.activeSelf)
            {
                escMenu.SetActive(false);
                Time.timeScale = 1f;
                return;
            }

            escMenu.SetActive(true);
            Time.timeScale = 0f;
            
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            if(SceneManager.GetActiveScene().buildIndex == 1)
            {
                Destroy(gameObject);
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
