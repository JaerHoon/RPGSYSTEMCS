using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [HideInInspector]
    public SkillData skillData;
    
    [HideInInspector]
    public string skillName;
    [HideInInspector]
    public SkillData.SkillType skillType;
    [HideInInspector]
    public int CharacterID;
    [HideInInspector]
    public string skillDescription;
    [HideInInspector]
    public Sprite SkillIcon;
    [HideInInspector]
    public StatName SkillPow;
    [HideInInspector]
    public StatName Lv;
    [HideInInspector]
    public StatName LvUPRate;
    public int DataIndex;
    public List<Intstat> intstats = new List<Intstat>();
    public List<Floatstat> floatstats = new List<Floatstat>();

    public UIData uIData = new UIData();


    public virtual void Init(SkillData data)
    {
        skillName = data.skillName;
        skillDescription = data.skillDescription;
        SkillIcon = data.SkillIcon;
        Lv = data.Lv;
        LvUPRate = data.LvUPRate;
        DataIndex = data.DataIndex;
        intstats.AddRange(data.intstats);
        floatstats.AddRange(data.floatstats);
        CharacterID = data.CharacterID;
      
    }

    public virtual void skillLvUP()
    {
       intstats[skillData.Lv.StatIndex].value++;
    }

    public virtual void OnSkill()
    {

    }

    public virtual void OngoingSkill()
    {

    }

    public virtual void OffSkill()
    {

    }

    public virtual int GetintSkillpow()
    {
        return intstats[skillData.SkillPow.StatIndex].value
               * intstats[skillData.Lv.StatIndex].value
               * intstats[skillData.LvUPRate.StatIndex].value;
    }

    public virtual float GetfloatSkillpow()
    {
        return floatstats[skillData.SkillPow.StatIndex].value
               * floatstats[skillData.Lv.StatIndex].value
               * floatstats[skillData.LvUPRate.StatIndex].value;
    }

    public virtual UIData GetUIdata()
    {
        uIData.Reset();
        uIData.SetUIdata<Skill>(this);

        return uIData;
    }

}
