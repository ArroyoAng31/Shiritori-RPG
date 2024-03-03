using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Text that shows can be set to show up

[System.Serializable]//makes these options show up in Unity
public class TextTest 
{
    public string name;

    [TextArea(3, 10)]// size of the previewed textbox 
    public string[] sentences;
}
