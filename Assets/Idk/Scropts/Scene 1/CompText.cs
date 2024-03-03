using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompText : MonoBehaviour
{    
    private string currentText;
    public GameObject gameText;

    public void startTxt(int score)
    {
        Debug.Log("Enemies Defeated " + score);
        Debug.Log("\t\t Player Vs. Computer ");
        Debug.Log("");
        Debug.Log("\t\t\tStart!");
        
        gameText.GetComponent<Text>().text = currentText += ("Enemies Defeated " + score);
        gameText.GetComponent<Text>().text = currentText += ("\n\t\t Player Vs. Computer ");
        gameText.GetComponent<Text>().text = currentText += ("\n");
        gameText.GetComponent<Text>().text = currentText += ("\n\t\t\tStart!");
    }

    public void playerTurnTxt(int difficulty, char randChar)
    {
        Debug.Log("Difficulty is " + difficulty);
        Debug.Log("");
        Debug.Log("Player's Turn : ");
        Debug.Log("");
        Debug.Log("Starting Letter : " + randChar);
        Debug.Log("Word : ? (Type \"I_quit\" to Give Up)");

        gameText.GetComponent<Text>().text = currentText += ("\nDifficulty is " + difficulty);
        gameText.GetComponent<Text>().text = currentText += ("\n");
        gameText.GetComponent<Text>().text = currentText += ("\nPlayer's Turn : ");
        gameText.GetComponent<Text>().text = currentText += ("\n");
        gameText.GetComponent<Text>().text = currentText += ("\nStarting Letter : " + randChar);
        gameText.GetComponent<Text>().text = currentText += ("\nWord : ? (Type \"I_quit\" to Give Up)");
    }

    public void wordNoExistTxt(char randChar)
    {
        Debug.Log("No Such Word!! Try Again!");
        Debug.Log("Word : ? ");
        Debug.Log("letter is " + randChar);

        gameText.GetComponent<Text>().text = currentText += ("\nNo Such Word!! Try Again!");
        gameText.GetComponent<Text>().text = currentText += ("\nWord : ? ");
        gameText.GetComponent<Text>().text = currentText += ("\nletter is " + randChar);
    }

    public void playerTurnNoWords()
    {
        Debug.Log("");
        Debug.Log("\t\t\tPlayer Has Run Out Of Words!");
        Debug.Log("\t\t\tComputer Wins!");

        gameText.GetComponent<Text>().text = currentText += ("\n");
        gameText.GetComponent<Text>().text = currentText += ("\n\t\t\tPlayer Has Run Out Of Words!");
        gameText.GetComponent<Text>().text = currentText += ("\n\t\t\tComputer Wins!");
    }

    public void playerWordNotStartChar(char randChar)
    {
        Debug.Log("Word does not start with " + randChar);

        gameText.GetComponent<Text>().text = currentText += ("\nWord does not start with " + randChar);
    }

    public void computerStartLetter(char randChar)
    {
        Debug.Log("");
        Debug.Log("\t\t\t\tComputer's Turn : ");
        Debug.Log("");
        Debug.Log("\t\t\tStarting Letter : " + randChar);
        Debug.Log("\t\t\tWord : ? ");
    }
}
