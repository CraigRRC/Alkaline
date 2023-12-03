using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogsData : MonoBehaviour
{
    public Text[] logs;
    public Image[] logImages;

    private void Awake()
    {
        logs = GetComponentsInChildren<Text>();
        logImages = GetComponentsInChildren<Image>();
    }
}
