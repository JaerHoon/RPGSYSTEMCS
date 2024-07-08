using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : Manager<SkillManager>
{
    [SerializeField]
    protected List<Skill> allSkills = new List<Skill>();
    protected List<List<Skill>> characterSkills = new List<List<Skill>>();
    public List<string> KeyName = new List<string>();

    protected virtual void Init()
    {
        
    }

    protected virtual void ListingSkill()
    {
        for (int i = 0; i < allSkills.Count; i++)
        {
            if (allSkills[i].CharacterID == i)
            {
                characterSkills[i].Add(allSkills[i]);
            }
        }
    }

    public List<List<Skill>> Getcharacterskills()
    {
        return characterSkills;
    }

    public List<string> GetKeyName()
    {
        KeyName.AddRange(Utility.Getfields(typeof(SkillData)));
        return KeyName;
    }

    public virtual List<UIData> GetUIDatas(List<Skill> skills)
    {
        List<UIData> uIdatas = new List<UIData>();
        foreach (var C in skills)
        {
            uIdatas.Add(C.GetUIdata());
        }

        return uIdatas;
    }
}
