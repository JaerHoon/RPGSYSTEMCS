using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Linq;
using System.Reflection;

[CustomEditor(typeof(SlotGroup), true)]
public class SlotGroupEditor : Editor
{
    SlotGroup slotGroup;
    public override void OnInspectorGUI()
    {
        slotGroup = (SlotGroup)target;

        slotGroup.board = Utility.FindComponentInParent<UIBoard>(slotGroup.transform);

        EditorGUI.BeginDisabledGroup(true);
        EditorGUILayout.TextField("BoardName", slotGroup.board.name);
        EditorGUI.EndDisabledGroup();

        slotGroup.board.SetSlotGroups(slotGroup);

        if (slotGroup.board != null)
        {
            if (GUILayout.Button("SetSlots"))
            {
                slotGroup.SetSlots();

            }

            Type type = slotGroup.board.GetType();


            string[] listNames = type.GetFields(BindingFlags.Public | BindingFlags.Instance)
                            .Where(fi => fi.FieldType.IsGenericType && fi.FieldType.GetGenericTypeDefinition() == typeof(List<>) || fi.FieldType.IsArray)
                            .Select(fi => fi.Name).ToArray();

            if (listNames.Length > 0)
            {
                int index = Array.IndexOf(listNames, slotGroup.listName);
                if (index == -1) index = 0;
                index = EditorGUILayout.Popup("ListName", index, listNames);

                slotGroup.listName = listNames[index];
            }



        }



        if (GUI.changed)
        {
            EditorUtility.SetDirty(slotGroup);
        }
    }
}
