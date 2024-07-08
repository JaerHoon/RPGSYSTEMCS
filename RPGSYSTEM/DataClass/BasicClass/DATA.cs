using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Reflection;

public class DATA : ScriptableObject
{
    public int DataIndex;
    public List<Intstat> intstats = new List<Intstat>();
    public List<Floatstat> floatstats = new List<Floatstat>();

  
    public int GetintField(StatName stat)
    {
        int A = intstats[stat.StatIndex].value;
        return A;
    }

    public float Getfloatfield(StatName stat)
    {
        float A = floatstats[stat.StatIndex].value;
        return A;
    }

    public void SetupStatsOnce()
    {
        if (intstats.Count > 0 || floatstats.Count > 0)
        {
            return;
        }
        else
        {
            
            SetData();
        }


        // 이 함수는 한 번 호출된 후에는 더 이상 호출되지 않도록 만들어집니다.
        UnityEditor.EditorApplication.delayCall -= SetupStatsOnce;
    }



    public void SetData()
    {
        Type type = this.GetType();
        FieldInfo[] fields =  type.GetFields(BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance)
                            .Where(f => f.FieldType == typeof(StatName)).ToArray();
        
        for (int i = 0; i < fields.Length; i++)
        {
            StatName statSetup = fields[i].GetValue(this) as StatName;

            if (statSetup.Stattype == typeof(int))
            {
                //Intstat intstat = new Intstat(statSetup, fields[i].Name, statSetup.StatIndex);
               // intstats.Add(intstat);
            }
            else if (statSetup.Stattype == typeof(float))
            {
               // Floatstat floatstat = new Floatstat(statSetup, fields[i].Name, statSetup.StatIndex);
                //floatstats.Add(floatstat);
            }
        }
    }

}
