using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment 
{
    public int Index;
    
    protected EquipmentData equipmentData;
    [HideInInspector]
    public string equipmentName;
    [HideInInspector]
    public Sprite Icon;
    [HideInInspector]
    public EquipmentData.EquipmentType equipmentType;
    [HideInInspector]
    public EquipmentData.EquipmentGrade equipmentGrade;

    [HideInInspector]
    public EquipmentStat mainStat1;
    [HideInInspector]
    public EquipmentStat mainStat2;
    [HideInInspector]
    public EquipmentStat maninStat3;
    [HideInInspector]
    public EquipmentStat subtata1;
    [HideInInspector]
    public EquipmentStat subtata2;
    [HideInInspector]
    public EquipmentStat subtata3;
    [HideInInspector]
    public EquipmentStat subtata4;

    protected List<EquipmentStat> MainStat = new List<EquipmentStat>();
    protected List<EquipmentStat> SubStat = new List<EquipmentStat>();
    public UIData uIData;

    protected bool IsEquipment;

    public Equipment(EquipmentData Data)
    {
        equipmentData = Data;
        equipmentName = Data.equipmentName;
        Icon = Data.Icon;
        equipmentType = Data.equipmentType;
        equipmentGrade = Data.equipmentGrade;
        

        // 장비 타입에 따라서 메인 스탯정해짐
        // 장비 등급에 따라서 서브 스탯이 정해짐
    }

    public virtual List<EquipmentStat> GetMainStat()
    {
        return MainStat;
    }

    public virtual List<EquipmentStat> GetSubStat()
    {
        return SubStat;
    }

    public virtual void OnEquip()
    {
        IsEquipment = true;
    }

    public virtual void OffEquip()
    {
        IsEquipment = false;
    }

    public virtual UIData GetUIdata()
    {
        uIData.Reset();
        uIData.SetUIdata<Equipment>(this);
        return uIData;
    }
}
