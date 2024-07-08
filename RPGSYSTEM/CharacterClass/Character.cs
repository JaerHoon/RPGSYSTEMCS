using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public class Character
{
    public int CharacterID;
    public CharacterData CharacterData;
    public string CharacterName;
    public string Description;
    public Sprite Icon;
    public Intstat HP;
    public Intstat MP;
    public Intstat Exp;
    public Intstat ATKPow;
    public Floatstat DFN;


    protected List<Equipment> equipments = new List<Equipment>();

    protected List<Skill> skills = new List<Skill>();
    protected List<Skill> activeSkills = new List<Skill>();
    protected List<Skill> equipedSkills = new List<Skill>();

    
    public UIData uIData = new UIData();

    protected void ReSetStats()
    {
        
    }

    public Character(CharacterData data)
    {
        CharacterData = data;
        CharacterName = data.CharacterName;
        Description = data.Description;
        Icon = data.Icon;
        HP = new Intstat(data.HP);
        MP = new Intstat(data.MP);
        Exp = new Intstat(data.Exp);
        ATKPow = new Intstat(data.ATKPow);
        DFN = new Floatstat(data.DFN);
       

        CharacterID = data.DataIndex;
        //equipments 갯수 초기화 
        //equipSkills 갯수 초기화
        ReSetStats();
    }

    public virtual void SetSkill(List<Skill> skills)
    {
        this.skills.AddRange(skills);
        skills = skills.OrderBy(sk => sk.skillData.DataIndex).ToList();
    }

    public virtual void EquipSkill(int slotnum, Skill skill)
    {
        for (int i = 0; i < equipedSkills.Count; i++)
        {
            if (equipedSkills[i] = skill)
            {
                equipedSkills[i] = null;
            }
        }

        equipedSkills[slotnum] = skill;
    }

    public virtual void AtiveSkill(Skill skill)
    {
        activeSkills.Add(skill);
        activeSkills = activeSkills.OrderBy(sk => sk.skillData.DataIndex).ToList();
    }

    

    public virtual void EquipEquipment(Equipment equipment)
    {
        equipments[(int)equipment.equipmentType] = equipment;
    }

    public virtual void UnEquipEquipment(Equipment equipment)
    {
        equipments[(int)equipment.equipmentType] = null;
    }
        

    public virtual UIData GetUIdata()//한번만 호출해도 된다.
    {
        uIData.Reset();
        uIData.SetUIdata<Character>(this);
      
        return uIData;
    } 

}
