using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIComponents : MonoBehaviour
{
    public enum HierarchyType { BoardInfo, Slot, Card }
    [HideInInspector]
    public HierarchyType hierarchyType;

    public enum ComponentType { Image, TextMeshProUGUI, Slider }
    [HideInInspector]
    public ComponentType componentType;
    [HideInInspector]
    public UIBoard board;
    [HideInInspector]
    public SlotView slot;
    [HideInInspector]
    public string listName;
    [HideInInspector]
    public string KeyName;
    [HideInInspector]
    public int SlotIndex;

    public void SetParents(SlotView slotView)
    {
        board = slotView.myBoard;
        slot = slotView;
        SlotIndex = slotView.SlotIndex;
    }
}
