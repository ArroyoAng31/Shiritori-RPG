using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUsage : MonoBehaviour
{
    private ClassSkills skillInUse;
    private int skillType;
    SkillCalculations skCalc = new SkillCalculations();

    public void clickedSkill()
    {
        skillType = skillInUse.getSkillType();
        if(skillType == 0)
        {
            skCalc.clickedDefSkill();
        }
        else if(skillType == 1)
        {
            skCalc.clickedHealingSkill(); 
        }
        else if(skillType == 2)
        {
            skCalc.clickedAtkSkill();
        }

    }

}
