using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CS_ScreenController : MonoBehaviour
{
    public GameObject departButton;
    public GameObject awakeButton;
    public InputField digitOne;
    public InputField digitTwo;
    public InputField digitThree;
    public InputField digitFour;
    public GameObject passwordSprite;
    public GameObject codeInputBox;

    private bool correctPassword;
    private bool correctPasswordEndingTwo;

    private void Awake()
    {
        departButton.SetActive(false);
        awakeButton.SetActive(false);
    }

    private void Update()
    {
        if(correctPassword)
        {
            passwordSprite.SetActive(false);
            codeInputBox.SetActive(false);
            departButton.SetActive(true);
            //Show Depart Button
            //Remove Password decals
            Debug.Log("Correct pass");
        }
        else if (correctPasswordEndingTwo)
        {
            //Show Depart button
            //Show Awake Button
            //Remove password decals
        }

        if(digitOne.text == "0" && digitTwo.text == "8" && digitThree.text == "1" && digitFour.text == "0")
        {
            correctPassword = true;
        }
    }
}
