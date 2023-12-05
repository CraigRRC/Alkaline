using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MiscControls : MonoBehaviour
{
    private GameObject escMenu;
    private GameObject HUD;
    private GameObject logsUI;
    

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
            if(logsUI == null)
            {
                logsUI = FindObjectOfType<Camera>().gameObject.transform.GetChild(1).gameObject;
            }
            if (HUD == null)
            {
                HUD = FindObjectOfType<Camera>().gameObject.transform.GetChild(0).gameObject;
            }

            if (escMenu.activeSelf)
            {
                escMenu.SetActive(false);
                Time.timeScale = 1f;
                return;
            }
            if (!logsUI.activeSelf)
            {
                escMenu.SetActive(true);
                Time.timeScale = 0f;
            }
            if (HUD != null && !escMenu.activeSelf && logsUI.activeSelf)
            {
                //Bugged
                ////Simulate close button.
                //HUD.SetActive(true);
                //logsUI.SetActive(false);
               
            }
            

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
