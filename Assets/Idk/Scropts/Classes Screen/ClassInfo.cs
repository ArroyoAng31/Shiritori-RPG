using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ClassInfo : MonoBehaviour
{
    Swordsman swm = new Swordsman();
    Ranger rng = new Ranger();
    Mage mge = new Mage();
    Healer hlr = new Healer();
    public GameObject classTxt;
    public GameObject selectedTxt;
    private string currentClass;
    private string currentClassTxt;

    public void SwordsmanInfo()
    {
        currentClass = swm.getClassName();

        currentClassTxt = swm.getClassName() + ":";
        currentClassTxt += "\n" + swm.getClassDescription();
        currentClassTxt += "\nHealth: " + swm.getHealthValue();
        currentClassTxt += "\nAttack: " + swm.getAttackPwr();
        currentClassTxt += "\nDefense: " + swm.getDefensePwr();
        classTxt.GetComponent<Text>().text = currentClassTxt;
    }

    public void RangerInfo()
    {
        currentClass = rng.getClassName();

        currentClassTxt = rng.getClassName() + ":";
        currentClassTxt += "\n" + rng.getClassDescription();
        currentClassTxt += "\nHealth: " + rng.getHealthValue();
        currentClassTxt += "\nAttack: " + rng.getAttackPwr();
        currentClassTxt += "\nDefense: " + rng.getDefensePwr();
        classTxt.GetComponent<Text>().text = currentClassTxt;
    }

    public void MageInfo()
    {
        currentClass = mge.getClassName();

        currentClassTxt = mge.getClassName() + ":";
        currentClassTxt += "\n" + mge.getClassDescription();
        currentClassTxt += "\nHealth: " + mge.getHealthValue();
        currentClassTxt += "\nAttack: " + mge.getAttackPwr();
        currentClassTxt += "\nDefense: " + mge.getDefensePwr();
        classTxt.GetComponent<Text>().text = currentClassTxt;
    }

    public void HealerInfo()
    {
        currentClass = hlr.getClassName();

        currentClassTxt = hlr.getClassName() + ":";
        currentClassTxt += "\n" + hlr.getClassDescription();
        currentClassTxt += "\nHealth: " + hlr.getHealthValue();
        currentClassTxt += "\nAttack: " + hlr.getAttackPwr();
        currentClassTxt += "\nDefense: " + hlr.getDefensePwr();
        classTxt.GetComponent<Text>().text = currentClassTxt;
    }

    public void SelectedClass()
    {
        PlayerPrefs.SetString("SelectedClass", currentClass);

        selectedTxt.GetComponent<Text>().text = currentClass + " was selected!";
    }
}
