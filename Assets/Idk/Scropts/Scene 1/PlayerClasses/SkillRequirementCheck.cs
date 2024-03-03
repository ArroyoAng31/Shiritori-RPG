using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillRequirementCheck
{
    private PlayerClass classUsed;
    private Dictionary<int, ClassSkills> classSkillsDictionary;
    private ClassSkills currentSkill;
    private bool isPassive = false;
    private double mpNeeded = 0.0;

    //Set Active Skills to Buttons and Passive to text info
    public void PassiveOrActive(PlayerClass pc)
    {
        classUsed = pc;
        classSkillsDictionary = classUsed.getClassSkills();

        for (int i = 0; i < classSkillsDictionary.Count; i++)
        {
            currentSkill = classSkillsDictionary[i];
            isPassive = currentSkill.getIsPassive();

            if(isPassive == true)
            {
                SettingSkills.FindObjectOfType<SettingSkills>().SettingPassive(currentSkill);
            }
            else
            {
                SettingSkills.FindObjectOfType<SettingSkills>().SettingActive(currentSkill);
            }

        }
    }

    //check to see if player has enough MP to use a skill
    public void UsableSkill(PlayerClass pc, double currentMP)
    {
        classUsed = pc;
        classSkillsDictionary = classUsed.getClassSkills();

        for(int i = 0; i < classSkillsDictionary.Count; i++)
        {
            currentSkill = classSkillsDictionary[i];
            isPassive = currentSkill.getIsPassive();
            mpNeeded = currentSkill.getSkillMPNeeded();

            if(isPassive != true && currentMP > mpNeeded)
            {
                SettingSkills.FindObjectOfType<SettingSkills>().turnOnActive();
            }
            else if(isPassive != true && currentMP < mpNeeded)
            {
                SettingSkills.FindObjectOfType<SettingSkills>().turnOffActive();
            }
        }
    }
}
