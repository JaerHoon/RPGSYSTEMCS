using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Stat 
{
    public int statIndex;
    

}
[Serializable]
public class Intstat : Stat
{
    public int value;
    public List<int> EquipmentUPValue = new List<int>();
    public List<int> temp_value = new List<int>();


    public Intstat(Intstat data)
    {
        value = data.value;
    }

    public int GetBasicValue()
    {
        return value;
    }

    public int GetEquipedValue()
    {
        int va = value;

        foreach (int a in EquipmentUPValue)
        {
            va += a;
        }

        return va;
    }

    public int GetAllValue()
    {
        int va = value;

        foreach(int a in EquipmentUPValue)
        {
            va += a;
        }

        foreach(int b in temp_value)
        {
            va += b;
        }

        return va;
    }

    public void SetValue(int amount)
    {
        value += amount;
    }
    public void Settempstat(int amount)
    {
        temp_value.Add(amount);
    }
    public void Restoretmepstat(int amount)
    {
        temp_value.Remove(amount);
    }

    public void ReSetTempStat()
    {
        temp_value.Clear();
    }

    public void SetEquipmentValue(List<int> amounts)
    {
        EquipmentUPValue = amounts;
    }
       
}

[Serializable]
public class Floatstat :Stat
{
    public float value;
    public List<float> EquipmentUPValue = new List<float>();
    public List<float> temp_value = new List<float>();

    public Floatstat(Floatstat data)
    {
        value = data.value;
    }

    public float GetBasicValue()
    {
        return value;
    }

    public float GetEquipedValue()
    {
        float va = value;

        foreach (float a in EquipmentUPValue)
        {
            va += a;
        }

        return va;
    }

    public float GetAllValue()
    {
        float va = value;

        foreach (float a in EquipmentUPValue)
        {
            va += a;
        }

        foreach (float b in temp_value)
        {
            va += b;
        }

        return va;
    }

    public void SetValue(float amount)
    {
        value += amount;
    }
    public void Settempstat(float amount)
    {
        temp_value.Add(amount);
    }
    public void Restoretmepstat(float amount)
    {
        temp_value.Remove(amount);
    }

    public void ReSetTempStat()
    {
        temp_value.Clear();
    }

    public void SetEquipmentValue(List<float> amounts)
    {
        EquipmentUPValue = amounts;
    }
}


public class StatName
{
    public readonly int StatIndex;
    public readonly Type Stattype;

    public StatName(Type type, int statindex)
    {
        StatIndex = statindex;
        Stattype = type;
    }
}

public class EquipmentStat : Stat
{
    public string statName;
    public Enums.StatType statType;
    public float maxValue;
    public float minValue;
    public float Value;

    public EquipmentStat(string statname ,float MaxAmount, float minAmount)
    {
        statName = statname;
        Value = UnityEngine.Random.Range(MaxAmount, minAmount);
    }

    public int GetIntAmount()
    {
        int A = Mathf.RoundToInt(Value);
        return A;
    }

    public float GetFloatAmount()
    {
        return Value;
    }
}

public class SliderStat : Stat
{
    public string name;
    public string nameMax;
    public string nameCur;
    public Enums.StatType statType;
    protected float maxValue;
    public float curValue;

    public SliderStat(string name, Enums.StatType type, float max, float cur)
    {
        this.name = name;
        nameMax = name+"Max";
        nameCur = name + "Cur";
        statType = type;
        maxValue = max;
        curValue = cur;
    }

    public int[] GetIntAmount()
    {
        int[] A = { Mathf.RoundToInt(maxValue), Mathf.RoundToInt(curValue) };
        return A;
    }

    public float[] GetfloatAmount()
    {
        float[] A = { maxValue, curValue };
        return A;
    }
}