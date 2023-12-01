using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LE_ScreenController : MonoBehaviour
{
    public GameObject confirmButton;
    public GameObject successDescription;
    public GameObject invertProcess;
    public GameObject codeInputBox;
    public InputField inputOne;
    public InputField inputTwo;
    public InputField inputThree;

    private bool cureSuccess = false;

    private void Awake()
    {
        confirmButton.SetActive(false);
        successDescription.SetActive(false);
    }

    private void Update()
    {
        if (cureSuccess)
        {
            //Turn off this screen
            invertProcess.SetActive(false);
            codeInputBox.SetActive(false);
            confirmButton.SetActive (true);
            successDescription.SetActive (true);
        }

        if ((inputOne.text == "0.9" || inputOne.text.Trim() == ".9") &&  
            (inputTwo.text == "0.5" || inputTwo.text.Trim() == ".5") && 
            (inputThree.text == "0.8" || inputThree.text.Trim() == ".8"))
        {
            cureSuccess = true;
        }
    }
}
