using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassInUse
{
    PlayerClass defaultClass = new PlayerClass();
    private string currentClassUsed;

    public PlayerClass PlayerClassUsed(string j)
    {
        currentClassUsed = j;

        switch (currentClassUsed)
        {
            case "Swordsman":
                {
                    Swordsman swordsman = new Swordsman();
                    return swordsman;
                }

            case "Ranger":
                {
                    Ranger ranger = new Ranger();
                    return ranger;
                }

            case "Mage":
                {
                    Mage mage = new Mage();
                    return mage;
                }

            case "Healer":
                {
                    Healer healer = new Healer();
                    return healer;
                }

            default:
                {
                    Debug.Log("There Be Issues With Class Selection PLZ FIX");
                    return defaultClass;
                }
        }
    }
}
