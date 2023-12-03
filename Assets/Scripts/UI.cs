using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



//Class that will be used to handle the UI for the player
//Changes to the UI will be made dynamically and persist.
//Needs to handle various things like the battery meter, and the logs that have been acquired.
public class UI : MonoBehaviour
{
    public Image[] OriginalBatteryCharges;
    public Text levelNum;

    private void Awake()
    {
        if (levelNum != null)
            levelNum.text = SceneManager.GetActiveScene().buildIndex.ToString();
    }
}
