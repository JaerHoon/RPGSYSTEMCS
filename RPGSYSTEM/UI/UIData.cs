using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Reflection;

public class UIData : MonoBehaviour
{
    public Dictionary<string, Sprite> imageValue;
    public Dictionary<string, int> intValue;
    public Dictionary<string, float> floatValue;
    public Dictionary<string, string> stringValue;
    public Dictionary<string, SliderStat> sliderValue;
    public Dictionary<string, Intstat> intstatvalue;
    public Dictionary<string, Floatstat> floatstatvalue;

    List<FieldInfo> AllFields = new List<FieldInfo>();
    List<PropertyInfo> Allrpoperties = new List<PropertyInfo>();

    public void SetUIdata<T>(T Class) where T : class
    {
        Type type = Class.GetType();

        if(AllFields.Count <= 0)
        {
            AllFields = type.GetFields(BindingFlags.Public | BindingFlags.Instance).ToList();
        }

        if(Allrpoperties.Count <= 0)
        {
            Allrpoperties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
        }

        FieldInfo[] intfields = AllFields.Where(f => f.FieldType == typeof(int)).ToArray();
        SetfieldtoDic<T>(intfields, typeof(int), Class);
        FieldInfo[] spritedields = AllFields.Where(f => f.FieldType == typeof(Sprite)).ToArray();
        SetfieldtoDic<T>(spritedields, typeof(Sprite), Class);
        FieldInfo[] floatfields = AllFields.Where(f => f.FieldType == typeof(float)).ToArray();
        SetfieldtoDic<T>(floatfields, typeof(float), Class);
        FieldInfo[] stringfields = AllFields.Where(f => f.FieldType == typeof(string)).ToArray();
        SetfieldtoDic<T>(stringfields, typeof(string), Class);

        FieldInfo[] IntStatfields = AllFields.Where(f => f.FieldType == typeof(Intstat)).ToArray();
        foreach(var intstat in IntStatfields)
        {
            intstatvalue.Add(intstat.Name, intstat.GetValue(Class) as Intstat);
           
        }

        FieldInfo[] floatStatfields = AllFields.Where(f => f.FieldType == typeof(Floatstat)).ToArray();
        foreach(var stat in floatStatfields)
        {
            floatstatvalue.Add(stat.Name, stat.GetValue(Class) as Floatstat);
          
        }

        FieldInfo[] sliderstatfields = AllFields.Where(f => f.FieldType == typeof(SliderStat)).ToArray();
        foreach(var stat in sliderstatfields)
        {
            sliderValue.Add(stat.Name, stat.GetValue(Class) as SliderStat);
            
        }

        FieldInfo[] equipmentstatfields = AllFields.Where(f => f.FieldType == typeof(EquipmentStat)).ToArray();
        foreach(var stat in equipmentstatfields)
        {
            EquipmentStat st = stat.GetValue(Class) as EquipmentStat;
            if(st.statType == Enums.StatType.Int)
            {
                intValue.Add(stat.Name, st.GetIntAmount());
            }
            else
            {
                floatValue.Add(stat.Name, st.GetFloatAmount());
            }
            
        }

        PropertyInfo[] intproperties = Allrpoperties.Where(f => f.PropertyType == typeof(int)).ToArray();
        SetProrpetytoDic<T>(intproperties, typeof(int), Class);
        PropertyInfo[] floatproperties = Allrpoperties.Where(f => f.PropertyType == typeof(float)).ToArray();
        SetProrpetytoDic<T>(floatproperties, typeof(float), Class);
        PropertyInfo[] spriteproperties = Allrpoperties.Where(f => f.PropertyType == typeof(Sprite)).ToArray();
        SetProrpetytoDic<T>(spriteproperties, typeof(Sprite), Class);
        PropertyInfo[] stringproperties = Allrpoperties.Where(f => f.PropertyType == typeof(string)).ToArray();
        SetProrpetytoDic<T>(stringproperties, typeof(string), Class);

        PropertyInfo[] IntStatpro = Allrpoperties.Where(f => f.PropertyType == typeof(Intstat)).ToArray();
        foreach (var intstat in IntStatpro)
        {
            intstatvalue.Add(intstat.Name, intstat.GetValue(Class) as Intstat);
           
        }

        PropertyInfo[] floatStatpro = Allrpoperties.Where(f => f.PropertyType == typeof(Floatstat)).ToArray();
        foreach (var stat in floatStatpro)
        {
            floatstatvalue.Add(stat.Name, stat.GetValue(Class) as Floatstat);
           
        }

        PropertyInfo[] sliderstatpro = Allrpoperties.Where(f => f.PropertyType == typeof(SliderStat)).ToArray();
        foreach (var stat in sliderstatpro)
        {
            sliderValue.Add(stat.Name, stat.GetValue(Class) as SliderStat);
            
        }
    }


   

    public void SetfieldtoDic<T>(FieldInfo[] fields, Type valueType, T Class) where T : class
    {
        foreach (FieldInfo field in fields)
        {
            if (valueType == typeof(int))
            {
                intValue.Add(field.Name, (int)field.GetValue(Class));
            }
            else if (valueType == typeof(float))
            {
                floatValue.Add(field.Name, (float)field.GetValue(Class));
            }
            else if (valueType == typeof(Sprite))
            {
                imageValue.Add(field.Name, (Sprite)field.GetValue(Class));
            }
            else if (valueType == typeof(string))
            {
                stringValue.Add(field.Name, (string)field.GetValue(Class));
            }

           
        }

    }

    public void SetProrpetytoDic<T>(PropertyInfo[] properties, Type valueType, T Class) where T : class
    {
        foreach (PropertyInfo field in properties)
        {
            if (valueType == typeof(int))
            {
                intValue.Add(field.Name, (int)field.GetValue(Class));

            }
            else if (valueType == typeof(float))
            {
                floatValue.Add(field.Name, (float)field.GetValue(Class));
            }
            else if (valueType == typeof(Sprite))
            {
                imageValue.Add(field.Name, (Sprite)field.GetValue(Class));
            }
            else if (valueType == typeof(string))
            {
                stringValue.Add(field.Name, (string)field.GetValue(Class));
            }

           
        }
    }


    public void Reset()
    {
        intValue.Clear();
        floatValue.Clear();
        imageValue.Clear();
        stringValue.Clear();
        sliderValue.Clear();
        intstatvalue.Clear();
        floatstatvalue.Clear();
    }
}

