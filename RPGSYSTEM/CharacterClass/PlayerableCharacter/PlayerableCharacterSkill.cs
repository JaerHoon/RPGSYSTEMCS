using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerableCharacterSkill : MonoBehaviour
{
    public List<IAtionSkill> ative_AtionSkills = new List<IAtionSkill>();
    public List<IPassiveSkill> ative_PassiveSkills = new List<IPassiveSkill>();
    public List<IConditionSkill> ative_ConditionSkills = new List<IConditionSkill>();
    public List<IBuffDebuffSkill> ative_BuffDeffSkills = new List<IBuffDebuffSkill>();


    public virtual void OnSkill(Skill skill)
    {
        skill.OnSkill();
        switch (skill.skillType)
        {
            case SkillData.SkillType.Ation:
                ative_AtionSkills.Add((IAtionSkill)skill);
                break;
            case SkillData.SkillType.Passive:
                ative_PassiveSkills.Add((IPassiveSkill)skill);
                break;
            case SkillData.SkillType.Condition:
                ative_ConditionSkills.Add((IConditionSkill)skill);
                break;
            case SkillData.SkillType.BuffDebuff:
                ative_BuffDeffSkills.Add((IBuffDebuffSkill)skill);
                break;
        }
    }

    public virtual void CheckCondtion(Enums.SkillConditionType skillConditiontype)
    {
        for (int i = 0; i < ative_ConditionSkills.Count; i++)
        {
            if (ative_ConditionSkills[i].skillConditionType == skillConditiontype)
            {
                ative_ConditionSkills[i].CheckCondition();

            }
        }

    }
}