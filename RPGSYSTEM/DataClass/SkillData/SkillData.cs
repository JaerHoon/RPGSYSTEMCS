using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "ScriptableObjects/SkillData")]
public class SkillData : DATA
{
    [HideInInspector]
    public string skillName;
    [HideInInspector]
    public enum SkillType { Ation, Passive, Condition, BuffDebuff }
    [HideInInspector]
    public SkillType skillType;
    [HideInInspector]
    public int CharacterID;
    [HideInInspector]
    public string skillDescription;
    [HideInInspector]
    public Sprite SkillIcon;
    [HideInInspector]
    public StatName SkillPow = new StatName(typeof(int), 0);
    [HideInInspector]
    public StatName Lv = new StatName(typeof(int), 1);
    [HideInInspector]
    public StatName LvUPRate = new StatName(typeof(float), 0);
}
