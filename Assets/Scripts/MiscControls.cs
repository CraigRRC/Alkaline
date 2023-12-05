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
    private GameObject controlStationScreen;
    private GameObject labScreen;
    

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


            if(SceneManager.GetActiveScene().name == "Story_7")
            {
                if (controlStationScreen == null)
                {
                    controlStationScreen = FindObjectOfType<CS_ScreenController>(true).gameObject;
                }
                if (labScreen == null)
                {
                    labScreen = FindObjectOfType<LE_ScreenController>(true).gameObject;
                }
            }
            
            if (escMenu.activeSelf)
            {
                escMenu.SetActive(false);
                Time.timeScale = 1f;
                return;
            }

            if(SceneManager.GetActiveScene().name == "Story_7")
            {
                if (!logsUI.activeSelf && !controlStationScreen.activeSelf && !labScreen.activeSelf)
                {
                    escMenu.SetActive(true);
                    Time.timeScale = 0f;
                }
            }
            else
            {
                if (!logsUI.activeSelf)
                {
                    escMenu.SetActive(true);
                    Time.timeScale = 0f;
                }
            }

            
            if (HUD != null && !escMenu.activeSelf && logsUI.activeSelf)
            {
                //Simulate close button.
                HUD.SetActive(true);
                logsUI.SetActive(false);
            }
            if(controlStationScreen != null &&  !escMenu.activeSelf && !logsUI.activeSelf)
            {
                controlStationScreen.SetActive(false);
            }
            if (labScreen != null && !escMenu.activeSelf && !logsUI.activeSelf)
            {
                labScreen.SetActive(false);
            }

            //Level 7 stuff


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
