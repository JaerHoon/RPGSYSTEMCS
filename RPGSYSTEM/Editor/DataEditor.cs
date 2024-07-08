using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.Linq;

[CustomEditor(typeof(DATA), true)]
public class DataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        DATA data = (DATA)target;
        
        var statsType = target.GetType();

        // 먼저 자식 클래스 필드를 그립니다.
        var childFields = statsType.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                          .Where(fi => fi.FieldType != typeof(StatName)).ToArray();
                          
        

        foreach (var field in childFields)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty(field.Name), true);
            
        }
       
        // 부모 클래스 필드를 그립니다.
        var baseType = statsType.BaseType;
        

        var parentFields = baseType.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        foreach (var field in parentFields)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty(field.Name), true);
        }
          
        

        serializedObject.ApplyModifiedProperties();


        if (GUILayout.Button("Set Stat field"))
        {
            data.SetupStatsOnce();
            EditorUtility.SetDirty(data); // 데이터가 변경되었음을 Unity에 알림
        }
    }

        
}

