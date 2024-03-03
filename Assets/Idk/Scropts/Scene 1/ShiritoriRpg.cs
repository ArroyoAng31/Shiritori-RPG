using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShiritoriRpg : MonoBehaviour
{

    DictionaryEx.DictionaryUse newGame = new DictionaryEx.DictionaryUse();
    VersusComputer comp = new VersusComputer();
    static string player_Name = "Paul";
    Player player = new Player(player_Name);

    // Used to be in own class 
    public string wordTyped;
    public GameObject inputFieldExampl;
    public GameObject displayFieldExampl;

    // Start is called before the first frame update
    void Start()
    {
        // bool ending = false;
        StartCoroutine(comp.versus(newGame, player, this)); //comp.versus(newGame,player);
    }

    //Used to be in own class
    void Update()
    {
        wordTyped = inputFieldExampl.GetComponent<Text>().text;
        displayFieldExampl.GetComponent<Text>().text = wordTyped;

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            comp.WordReceived(wordTyped);
        }
    }

}
