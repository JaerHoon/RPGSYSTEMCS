using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Linq;
using System.Reflection;


[CustomEditor(typeof(UIComponents), true)]
public class UIComponentEditor : Editor
{
    UIComponents components;

    public override void OnInspectorGUI()
    {

        components = (UIComponents)target;

        components.hierarchyType = (UIComponents.HierarchyType)EditorGUILayout.EnumPopup("HierarchyType", components.hierarchyType);

        components.componentType = (UIComponents.ComponentType)EditorGUILayout.EnumPopup("ComponentType", components.componentType);

        if (components.hierarchyType == UIComponents.HierarchyType.Slot)
        {
            SlotView slotView = Utility.FindComponentInParent<SlotView>(components.transform);

            if (slotView != null)
            {
                components.SetParents(slotView);

                EditorGUI.BeginDisabledGroup(true);
                EditorGUILayout.IntField("SlotIndex", components.SlotIndex);
                EditorGUI.EndDisabledGroup();

                if (components.board != null)
                {
                    EditorGUI.BeginDisabledGroup(true);
                    EditorGUILayout.TextField("BoardName", components.board.name);
                    EditorGUI.EndDisabledGroup();

                    Type type = components.board.GetType();

                    string[] listName = type.GetFields(BindingFlags.Instance | BindingFlags.Public)
                                        .Where(n => n.FieldType == typeof(List<string>))
                                        .Select(n => n.Name).ToArray();
                    if (listName.Length > 0)
                    {
                        int id = Array.IndexOf(listName, components.listName);
                        if (id == -1) id = 0;
                        id = EditorGUILayout.Popup("KeyListName", id, listName);

                        components.listName = listName[id];

                        FieldInfo field = type.GetField(components.listName);
                        List<string> vs = field.GetValue(components.board) as List<string>;
                        string[] fieldNames = vs.ToArray();

                        if (fieldNames.Length > 0)
                        {
                            int index = Array.IndexOf(fieldNames, components.KeyName);
                            if (index == -1) index = 0;
                            index = EditorGUILayout.Popup("KeyName", index, fieldNames);

                            components.KeyName = fieldNames[index];
                        }
                    }




                }
            }


        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(components);
        }
    }
}
