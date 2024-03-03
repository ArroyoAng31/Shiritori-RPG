using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingSkills : MonoBehaviour
{
    private ClassSkills currentSkill;
    public GameObject buttonTxt;
    public GameObject passiveNameTxt;
    public GameObject passiveTxt;
    public GameObject button;
    public Transform skillButtonContainer;

    public void SettingPassive(ClassSkills cs)
    {
        passiveNameTxt.GetComponent<Text>().text = cs.getSkillName();
        passiveTxt.GetComponent<Text>().text = cs.getSkillDescription();
    }

    public void SettingActive(ClassSkills cs)
    {
        buttonTxt.GetComponent<Text>().text = cs.getSkillName();
    }

    public void turnOffActive()
    {
        button.GetComponent<Button>().interactable = false;
    }

    public void turnOnActive()
    {
        button.GetComponent<Button>().interactable = true;
    }
    
    public void setSkillButtons()
    {
        //for(int i = 1; i <= 20; i++)
        //{
        //    GameObject skButton = Instantiate(button) as GameObject;
        //    skButton.SetActive(true);

        //    skButton.GetComponent<ButtonListButton>().SetText("Button #" + i);

        //    skButton.transform.SetParent(buttonTemplate.transform.parent, false);
        //}

        //for (int i = 1; i <= 4; i++)
        //{
        //    GameObject skButton = Instantiate(button) as GameObject;
        //    skButton.SetActive(true);

        //    skButton.GetComponent<SkillPanelToggle>().SetText("Button #" + i);

        //    skButton.transform.SetParent(skillButtonContainer.transform.parent, false);

        //    skButton.GetComponent<Button>().onClick.AddListener(() => );
        //}
    }

}   
