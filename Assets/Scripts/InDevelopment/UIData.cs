using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIData : MonoBehaviour
{
    public static UIData Instance;
    private Image[] PersistingBatteryCharges;
    private UI HUD;
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
                Debug.Log(PersistingBatteryCharges[i].name);
            }
            maxDepletedBatteryCount = PersistingBatteryCharges.Length;
            for (int i = 0; i < depletedBatteryCount; i++)
            {
                PersistingBatteryCharges[i].enabled = false;
            }
            
        }
    }

    public void ReduceBattery()
    {
        if (PersistingBatteryCharges == null) return;

        if(depletedBatteryCount == maxDepletedBatteryCount)
        {
            //Turn off mags.
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
}
