using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class UIData : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip batteryDrain;
    public AudioClip batteryTic;
    public static UIData Instance;
    private Image[] PersistingBatteryCharges;
    private List<string> cachedLogs;
    private UI HUD;
    private LogsData logData;
    public Text[] persistingLogText;
    public Image[] persistingLogImage;
    public int depletedBatteryCount = 0;
    public int maxDepletedBatteryCount;
    private bool storyTwoComputerPass;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        cachedLogs = new List<string>();
    }

    private void Update()
    {
        if (Instance == null) return;
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(this.gameObject);
        }

        if (HUD == null)
        {
            HUD = FindObjectOfType<UI>();
            if(HUD == null)
            {
                return;
            }
            PersistingBatteryCharges = new Image[HUD.OriginalBatteryCharges.Length];
            for (int i = 0; i < HUD.OriginalBatteryCharges.Length; i++)
            {
                PersistingBatteryCharges[i] = HUD.OriginalBatteryCharges[i];
            }
            maxDepletedBatteryCount = PersistingBatteryCharges.Length;
            for (int i = 0; i < depletedBatteryCount; i++)
            {
                PersistingBatteryCharges[i].enabled = false;
            }
            
        }
       

        if (logData == null)
        {
            if(logData = FindObjectOfType<LogsData>())
            {
                logData.gameObject.SetActive(false);
                persistingLogText = new Text[logData.logs.Length];
                for (int i = 0; i < logData.logs.Length; i++)
                {
                    persistingLogText[i] = logData.logs[i];
                    persistingLogText[i].enabled = false;
                }
                if (persistingLogText.Length != 0)
                {
                    Debug.Log("Cash");
                    //Load the cached values.
                    for (int i = 0; i < cachedLogs.Count; i++)
                    {
                        Debug.Log(cachedLogs.Count);
                        for (int j = 0; j < persistingLogText.Length; j++)
                        {
                            Debug.Log(cachedLogs[i]);
                            Debug.Log(persistingLogText[j].text);
                            if (cachedLogs[i] == persistingLogText[j].text.Trim())
                            {
                                Debug.Log(cachedLogs[i]);
                                Debug.Log(persistingLogText[j].text);
                                persistingLogText[j].enabled = true;
                            }
                        }
                    }
                }

                ////Might not need this...?
                //persistingLogImage = new Image[logData.logImages.Length];
                //for (int i = 0; i < logData.logImages.Length; i++)
                //{
                //    if (logData.logImages[i].name == "close" ||
                //        logData.logImages[i].name == "dimBG" ||
                //        logData.logImages[i].name == "screen" ||
                //        logData.logImages[i].name == "clickformoredetail")
                //    {
                //        continue;
                //    }
                //    persistingLogImage[i] = logData.logImages[i];
                //    persistingLogImage[i].gameObject.SetActive(false);
                //}
            }
        }

    }

    public void AddLog(string log)
    {
        if(logData.gameObject.activeSelf)
        {
            logData.gameObject.SetActive(false);
        }
        else
        {
            logData.gameObject.SetActive(true);
        }
        
        if (persistingLogText.Length != 0)
        {
            foreach (var text in persistingLogText)
            {
                if (text == null) return;
            }
            //Add it directly.
            for (int i = 0; i < persistingLogText.Length; i++)
            {
                if (log.Trim() == persistingLogText[i].text.Trim())
                {
                    Debug.Log(persistingLogText[i]);
                    Debug.Log(log);
                    Debug.Log("Success!");
                    persistingLogText[i].enabled = true;
                    persistingLogText[i].gameObject.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
                    if (cachedLogs.Count == 0)
                    {
                        cachedLogs.Add(log);
                    }
                    else
                    {
                        foreach (var cachedLog in cachedLogs)
                        {
                            Debug.Log(cachedLog);
                            if (cachedLog != log)
                            {
                                Debug.Log(cachedLog);
                                cachedLogs.Add(log);
                                return;
                            }
                        }
                    }
                }
            }
        }
    }

    public void ReduceBattery()
    {
        if (PersistingBatteryCharges == null) return;
        
        PlayerSpawner levelManager2 = FindAnyObjectByType<PlayerSpawner>();
        if (levelManager2.magnetsInLvl.Count == 0)
            return;
        if (levelManager2.magnetsInLvl != null || levelManager2.magnetsInLvl.Count != 0)
        {
            foreach (var magnet in levelManager2.magnetsInLvl)
            {
                if (magnet == null) return;
            }
        }

        audioSource.clip = batteryTic;
        audioSource.Play();

        if (depletedBatteryCount == maxDepletedBatteryCount)
        {
            audioSource.clip = batteryDrain;
            audioSource.Play();
            //Turn off mags.
            PlayerSpawner levelManager = FindAnyObjectByType<PlayerSpawner>();
            if (levelManager != null)
            {
                foreach (var magnet in levelManager.magnetsInLvl)
                {
                    if (magnet != null)
                    {
                        magnet.TurnMagnetOff();
                    }
                }
            }
        }

        foreach (var battery in PersistingBatteryCharges)
        {
            if (battery.enabled)
            {
                battery.enabled = false;
                if (depletedBatteryCount < maxDepletedBatteryCount)
                {
                    depletedBatteryCount++;
                }
                return;
            }
        }
    }

    public void ChargeBattery()
    {
        if (PersistingBatteryCharges == null) return;
        if (depletedBatteryCount == maxDepletedBatteryCount)
        {
            Debug.Log("Here"); 
            //Turn on mags.
            //PlayerSpawner levelManager = FindAnyObjectByType<PlayerSpawner>();
            //if (levelManager != null)
            //{
            //    foreach (var magnet in levelManager.magnetsInLvl)
            //    {
            //        if (magnet != null)
            //        {
            //            magnet.TurnMagnetOn();
            //        }
            //    }
            //}
        }
        depletedBatteryCount = 0;
        foreach (var battery in PersistingBatteryCharges)
        {
            if (!battery.enabled)
            {
                battery.enabled = true;
            }
        }
    }

    public void LeaveTrigger()
    {
        logData.gameObject.SetActive(false);
    }
    public void CorrectPassword()
    {
        storyTwoComputerPass = true;
    }

    public bool GetPasswordStatus() { return storyTwoComputerPass; }
}
