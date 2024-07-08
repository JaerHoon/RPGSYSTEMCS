using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : Manager<EquipmentManager>
{
    [SerializeField]
    protected List<EquipmentData> equipmentDatas = new List<EquipmentData>();
    protected List<Equipment> createdEquipment = new List<Equipment>();
    protected List<Equipment> gainedEquipment = new List<Equipment>();
    public List<string> KeyName = new List<string>();
    
    public virtual void CreateEquipment(int DataIndex)
    {
        Equipment equipment = new Equipment(equipmentDatas[DataIndex]);
        createdEquipment.Add(equipment);
        //실제 게임상에 표시되는 아이템에 정보를 보낸다.
    }

    public virtual void GetEquipment(Equipment equipment)
    {
        gainedEquipment.Add(equipment);
        //얻은 아이템을 createdEquipment에서 제거해야 할 수도 있다.
    }

    public virtual void RemoveEquipment(Equipment equipment)
    {
        gainedEquipment.Remove(equipment);
    }

    public virtual List<string> GetKeyName()
    {
        KeyName.AddRange(Utility.Getfields(typeof(EquipmentData)));
        return KeyName;
    }
    
}
