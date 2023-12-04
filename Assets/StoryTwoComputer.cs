using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryTwoComputer : MonoBehaviour
{
    public Text one;
    public Text two;
    public Text three;
    public Text four;
    public GameObject codeInputBox;
    public GameObject lore;
    public bool correctPassword;



    private void Update()
    {
        if (one.text == "3" && two.text == "2" && three.text == "0" && four.text == "2")
        {
            correctPassword = true;
        }

        if(correctPassword)
        {
            //Turn off all this junk and turn on the other junk.
            codeInputBox.SetActive(false);
            lore.SetActive(true);
        }
    }
}
