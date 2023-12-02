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
            awakeButton.SetActive(correctPassword);
            //Show Depart Button
            //Remove Password decals
        }

        if(digitOne.text == "0" && digitTwo.text == "8" && digitThree.text == "1" && digitFour.text == "0")
        {
            correctPassword = true;
        }
    }

    public void SetEndingTwo() { correctPasswordEndingTwo = true; }
}
