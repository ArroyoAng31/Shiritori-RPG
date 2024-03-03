using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClassSkills 
{
    private protected String skillName;
    private protected String skillDescription;
    private protected double skillMPNeeded;
    private protected double skillModifiers;
    private protected bool isPassive;
    private protected int skillType; //0= defense,1= heal, 2=damage

    public ClassSkills(String skillName, String skillDescription, double skillMPNeeded, double skillModifiers, bool isPassive, int skillType)
    {
        this.skillName = skillName;
        this.skillDescription = skillDescription;
        this.skillMPNeeded = skillMPNeeded;
        this.skillModifiers = skillModifiers;
        this.isPassive = isPassive;
        this.skillType = skillType;
    }

    public String getSkillName()
    {
        return skillName;
    }

    public String getSkillDescription()
    {
        return skillDescription;
    }

    public double getSkillMPNeeded()
    {
        return skillMPNeeded;
    }

    public double getSkillModifiers()
    {
        return skillModifiers;
    }

    public bool getIsPassive()
    {
        return isPassive;
    }

    public int getSkillType()
    {
        return skillType;
    }
}