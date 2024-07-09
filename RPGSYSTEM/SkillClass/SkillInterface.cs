using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IAtionSkill
{
    [SerializeField]
    GameObject effectPrefab { get; set; }

    public void OnAtionSkill();
    public void OnSkillAttack();

}

public interface IPassiveSkill
{
    public void OnPassiveSkill();
}

public interface IConditionSkill
{
    public GameObject effectPrefab { get; set; }
    public Enums.SkillConditionType skillConditionType { get; set; }
    public void OnConditionSkill();
    public void CheckCondition();
    public void CompleteCondition();

}

public interface IBuffDebuffSkill
{
    public Enums.BuffDebuffType buffDebuffType { get; set; }

    public float duration { get; set; }
    public void OnBuffDebuffSkill();
}