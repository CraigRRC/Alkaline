using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIData : MonoBehaviour
{
    public static UIData Instance;
    private Image[] PersistingBatteryCharges;
    private List<string> cachedLogs;
    private UI HUD;
    private LogsData logData;
    public Text[] persistingLogText;
    public Image[] persistingLogImage;
    public int depletedBatteryCount = 0;
    public int maxDepletedBatteryCount;

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
        
        cachedLogs = new List<string>();
    }

    private void Update()
    {
        if (HUD == null)
        {
            HUD = FindObjectOfType<UI>();
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
                persistingLogText = new Text[logData.logs.Length];
                for (int i = 0; i < logData.logs.Length; i++)
                {
                    persistingLogText[i] = logData.logs[i];
                    persistingLogText[i].enabled = false;
                }
                if (persistingLogText.Length != 0)
                {
                    //Load the cached values.
                    for (int i = 0; i < cachedLogs.Count; i++)
                    {
                        for (int j = 0; j < persistingLogText.Length; j++)
                        {
                            if (cachedLogs[i] == persistingLogText[j].text)
                            {
                                persistingLogText[j].enabled = true;
                            }
                        }
                    }
                }

                persistingLogImage = new Image[logData.logImages.Length];
                for (int i = 0; i < logData.logImages.Length; i++)
                {
                    if (logData.logImages[i].name == "close" ||
                        logData.logImages[i].name == "dimBG" ||
                        logData.logImages[i].name == "screen")
                    {
                        continue;
                    }
                    persistingLogImage[i] = logData.logImages[i];
                    persistingLogImage[i].gameObject.SetActive(false);
                }
            }
        }

    }

    public void AddLog(string log)
    {
        Debug.Log(log);
        if (persistingLogText.Length != 0)
        {
            //Add it directly.
            for (int i = 0; i < persistingLogText.Length; i++)
            {

                if (log == persistingLogText[i].text)
                {
                    Debug.Log("Success!");
                    persistingLogText[i].enabled = true;
                }
            }
        }
        else
        {
            Debug.Log("Here");
            if(cachedLogs.Count == 0)
            {
                cachedLogs.Add(log);
            }
            else
            {
                foreach (var cachedLog in cachedLogs)
                {
                    if (cachedLog != log)
                    {
                        cachedLogs.Add(log);
                        return;
                    }
                }
            }
           
            
        }


    }

    public void ReduceBattery()
    {
        if (PersistingBatteryCharges == null) return;

        if(depletedBatteryCount == maxDepletedBatteryCount)
        {
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

        foreach(var battery in PersistingBatteryCharges)
        {
            if (battery.enabled)
            {
                battery.enabled = false;
                if(depletedBatteryCount < maxDepletedBatteryCount)
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
            PlayerSpawner levelManager = FindAnyObjectByType<PlayerSpawner>();
            if (levelManager != null)
            {
                foreach (var magnet in levelManager.magnetsInLvl)
                {
                    if (magnet != null)
                    {
                        magnet.TurnMagnetOn();
                    }
                }
            }
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
}
