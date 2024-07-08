using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentData", menuName = "ScriptableObjects/EquipmentData")]
public class EquipmentData : DATA
{
    [HideInInspector]
    public string equipmentName;
    [HideInInspector]
    public Sprite Icon;
    [HideInInspector]
    public enum EquipmentType { Weapon, Helmat, Armer, shoes, Accessories }
    [HideInInspector]
    public EquipmentType equipmentType;


    [HideInInspector]
    public enum EquipmentGrade { Normal, Rare, Uniqe, Legend }
    [HideInInspector]
    public EquipmentGrade equipmentGrade;

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

}
