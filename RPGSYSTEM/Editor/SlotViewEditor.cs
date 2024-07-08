using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SlotView), true)]
public class SlotViewEditor : Editor
{
    SlotView slot;

    public override void OnInspectorGUI()
    {
        slot = (SlotView)target;

        slot.SlotIndex = EditorGUILayout.IntField("SlotIdex", slot.SlotIndex);

        EditorGUI.BeginDisabledGroup(true);
        EditorGUILayout.TextField("BoardName", slot.myBoard.name);
        EditorGUI.EndDisabledGroup();



        if (GUI.changed)
        {
            EditorUtility.SetDirty(slot);
        }
    }
}
