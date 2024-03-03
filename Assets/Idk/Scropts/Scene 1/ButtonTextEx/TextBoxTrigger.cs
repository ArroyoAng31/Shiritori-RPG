using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Trigger to have the preset text show up

public class TextBoxTrigger : MonoBehaviour
{
    public TextTest text;   

    public void TriggerText()
    {
        FindObjectOfType<TextBox>().StartText(text);
    }
}
