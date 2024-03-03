using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerClass
{
    private protected String className { get; set; }
    private protected String classDescription { get; set; }
    private protected double healthValue { get; set; }
    private protected double mpValue { get; set; }
    private protected double attackPwr { get; set; }
    private protected double defensePwr { get; set; }
    private protected String classSprite { get; set; }

    public Dictionary<int, ClassSkills> classSkillsDictionary = new Dictionary<int, ClassSkills>();
    private protected ClassSkills currentSkill;
    private protected int skillNum = 0;

    private protected String skillName;
    private protected String skillDesc;
    private protected double skillMP;
    private protected double skillMod;
    private protected bool skillPassive;
    private protected int skillType;

    public PlayerClass() //default class
    {
        className = "Swordsman";
        classDescription = "A class that has a sword and a shield, you can take hits with higher health and higher defense while also dealing hits.";
        healthValue = 30;
        mpValue = 15;
        attackPwr = 1.1;
        defensePwr = 1.5;

        classSkillsDictionary.Clear(); // Resetting the dictionary... Idk if necessary?
        skillNum = 0;

        //Adding Skill Slash
        skillName = "Slash";
        skillMod = 2.0;
        skillMP = 5.0;
        skillDesc = "Swordsman skill damage: " + (skillMod * attackPwr);
        skillPassive = false;
        skillType = 2;

        currentSkill = new ClassSkills(skillName, skillDesc, skillMP, skillMod, skillPassive, skillType);
        classSkillsDictionary.Add(skillNum++, currentSkill);

        //Adding Passive Last Stand
        skillName = "Last Stand";
        skillMP = 0.0;
        skillMod = 1.0;
        skillDesc = "Swordsman passive";
        skillPassive = true;
        skillType = 0;

        currentSkill = new ClassSkills(skillName, skillDesc, skillMP, skillMod, skillPassive, skillType);
        classSkillsDictionary.Add(skillNum++, currentSkill);
    }

    public String getClassName()
    {
        return className;
    }

    public String getClassDescription()
    {
        return classDescription;
    }

    public double getHealthValue()
    {
        return healthValue;
    }

    public double getMPValue()
    {
        return mpValue;
    }

    public double getAttackPwr()
    {
        return attackPwr;
    }

    public double getDefensePwr()
    {
        return defensePwr;
    }

    public String getclassSprite()
    {
        return classSprite;
    }

    public Dictionary<int,ClassSkills> getClassSkills()
    {
        return classSkillsDictionary;
    }

}
public class Swordsman : PlayerClass
{
    public Swordsman() : base()
    {
        className = "Swordsman";
        classDescription = "A class that has a sword and a shield, you can take hits with higher health and higher defense while also dealing hits.";
        healthValue = 30;
        mpValue = 15;
        attackPwr = 1.1;
        defensePwr = 1.5;
        classSprite = @"Swordsman.PNG";

        classSkillsDictionary.Clear(); // Resetting the dictionary... Idk if necessary?
        skillNum = 0;

        //Adding Skill Slash
        skillName = "Slash";
        skillMod = 2.0;
        skillMP = 5.0;
        skillDesc = "Swordsman skill damage: " + (skillMod * attackPwr);
        skillPassive = false;
        skillType = 2;

        currentSkill = new ClassSkills(skillName, skillDesc, skillMP, skillMod, skillPassive, skillType);
        classSkillsDictionary.Add(skillNum++, currentSkill);
        //Adding Skill Slash
        skillName = "NOTSlash";
        skillMod = 2.0;
        skillMP = 5.0;
        skillDesc = "Swordsman skill damage: " + (skillMod * attackPwr);
        skillPassive = false;
        skillType = 2;

        currentSkill = new ClassSkills(skillName, skillDesc, skillMP, skillMod, skillPassive, skillType);
        classSkillsDictionary.Add(skillNum++, currentSkill);

        //Adding Passive Last Stand
        skillName = "Last Stand";
        skillMP = 0.0;
        skillMod = 2.0;
        skillDesc = "Swordsman passive";
        skillPassive = true;
        skillType = 0;

        currentSkill = new ClassSkills(skillName, skillDesc, skillMP, skillMod, skillPassive, skillType);
        classSkillsDictionary.Add(skillNum++, currentSkill);
    }
}

public class Ranger : PlayerClass
{
    public Ranger() : base()
    {
        className = "Ranger";
        classDescription = "A class that will rather attack from affar with high damage and not take any.";
        healthValue = 15;
        mpValue = 25;
        attackPwr = 1.4;
        defensePwr = 1.0;
        classSprite = @"Ranger.PNG";

        classSkillsDictionary.Clear(); // Resetting the dictionary... Idk if necessary?
        skillNum = 0;

        //Adding Skill Double Shot
        skillName = "Double Shot";
        skillMod = 2.0;
        skillMP = 7.0;
        skillDesc = "Ranger shoots twice doing: " + (skillMod * attackPwr);
        skillPassive = false;
        skillType = 2;

        currentSkill = new ClassSkills(skillName, skillDesc, skillMP, skillMod, skillPassive, skillType);
        classSkillsDictionary.Add(skillNum++, currentSkill);
    }
}

public class Mage : PlayerClass
{
    public Mage() : base()
    {
        className = "Mage";
        classDescription = "A fragile class with powerfull skills to destroy its enemies.";
        healthValue = 15;
        mpValue = 40;
        attackPwr = 1.0;
        defensePwr = 1.0;
        classSprite = @"Mage.PNG";

        classSkillsDictionary.Clear(); // Resetting the dictionary... Idk if necessary?
        skillNum = 0;

        //Adding Skill Fireball
        skillName = "Fireball";
        skillMod = 4.0;
        skillMP = 20.0;
        skillDesc = "Mage shoots a destructive fireball at its enemies dealing: " + (skillMod * attackPwr);
        skillPassive = false;
        skillType = 2;

        currentSkill = new ClassSkills(skillName, skillDesc, skillMP, skillMod, skillPassive, skillType);
        classSkillsDictionary.Add(skillNum++, currentSkill);
    }
}

public class Healer : PlayerClass
{
    public Healer() : base()
    {
        className = "Healer";
        classDescription = "A class that can heal itself to continue fighting.";
        healthValue = 20;
        mpValue = 35;
        attackPwr = 1.1;
        defensePwr = 1.0;
        classSprite = @"Healer.PNG";

        classSkillsDictionary.Clear(); // Resetting the dictionary... Idk if necessary?
        skillNum = 0;

        //Adding Skill Heal
        skillName = "Heal";
        skillMod = 10.0;
        skillMP = 15.0;
        skillDesc = "A spell that heals ones healthpoints: " + (skillMod * attackPwr);
        skillPassive = false;
        skillType = 1;

        currentSkill = new ClassSkills(skillName, skillDesc, skillMP, skillMod, skillPassive, skillType);
        classSkillsDictionary.Add(skillNum++, currentSkill);
    }
}



