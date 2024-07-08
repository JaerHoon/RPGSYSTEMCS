using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SlotGroup : MonoBehaviour
{
    [HideInInspector]
    public UIBoard board;
    [HideInInspector]
    public string listName;
    public List<SlotView> slots = new List<SlotView>();


    public List<ViewElement> GetSlotcomponents()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].GetSlotComponent();
        }

        List<ViewElement> slotsComponents = new List<ViewElement>();
        foreach (SlotView slot in slots)
        {
            slotsComponents.Add(slot.SlotComponents);
        }

        return slotsComponents;

    }

    public virtual void SetSlots()//자식에게 슬롯뷰를 붙여주고 리스트에 담는 함수
    {
        slots.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            SlotView slot = transform.GetChild(i).GetComponent<SlotView>();
            if (slot == null)
            {
                slot = transform.GetChild(i).gameObject.AddComponent<SlotView>();
            }

            slot.myBoard = board;
            slot.SlotIndex = i;
            slots.Add(slot);
        }

        slots = slots.OrderBy(slot => slot.SlotIndex).ToList();

    }
}
