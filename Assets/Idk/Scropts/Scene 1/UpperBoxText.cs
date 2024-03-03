using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpperBoxText : MonoBehaviour
{
    ImageToSprite iTS = new ImageToSprite();

    public GameObject playerName;
    public GameObject computerName;
    public GameObject playerHealth;
    public GameObject computerHealth;
    public GameObject playerMP;

    public GameObject playerSprite;
    public GameObject enemySprite;

    private string playerHVisual;
    private string compHVisual;

    private string playerMPVisual;

    public void InitializingNames(string playerN, string compN)
    {
        playerName.GetComponent<Text>().text = playerN;
        computerName.GetComponent<Text>().text = compN;
    }

    public void HealthVisual(double playerH, double compH, double startingPH, double startingCH)
    {
        playerHVisual = ("Health: " + playerH.ToString() + " / " + startingPH.ToString());
        playerHealth.GetComponent<Text>().text = playerHVisual;

        compHVisual = ("Health: " + compH.ToString() + " / " + startingCH.ToString());
        computerHealth.GetComponent<Text>().text = compHVisual;
    }

    public void MPVisual(double currentPlayerMP, double startingMP)
    {
        playerMPVisual = ("MP: " + currentPlayerMP.ToString() + " / " + startingMP.ToString());
        playerMP.GetComponent<Text>().text = playerMPVisual;
    }

    public void CallingImages(string playerImg, string enemyImg)
    {
        playerSprite.GetComponent<SpriteRenderer>().sprite = iTS.LoadSpriteFromImage(playerImg);

        enemySprite.GetComponent<SpriteRenderer>().sprite = iTS.LoadSpriteFromImage(enemyImg);
    }
}
