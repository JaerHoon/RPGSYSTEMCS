using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Reflection;

public class SlotBoard<T> : UIBoard
{
    public List<SlotGroup> slotGroups = new List<SlotGroup>();

    //슬롯들이 여러 종류가 있으니 Slot<T>의 슬롯을 상속받은 스크립트에서 만든다

    public virtual void Init()
    {
        if (slotGroups.Count > 0)
        {
            for (int i = 0; i < slotGroups.Count; i++)
            {
                slotGroups[i].SetSlots();//자식에게 슬롯뷰를 붙여주고 리스트에 담는 함수
                SetSlots(slotGroups[i]);
            }
        }
        else
        {
            Debug.Log("슬롯이 없습니다");
        }
    }

    public override void SetSlots(SlotGroup slotGroup)//슬롯에게 뷰엘리멘트(컴포넌트)를 세팅 
    {

        List<ViewElement> viewElements = slotGroup.GetSlotcomponents();

        Type type = this.GetType();
        FieldInfo field = type.GetField(slotGroup.listName, BindingFlags.Public | BindingFlags.Instance);

        if (field != null)
        {
            List<Slot<T>> fieldValue = field.GetValue(this) as List<Slot<T>>;

            if (fieldValue != null)
            {
                fieldValue.Clear();

                for (int i = 0; i < viewElements.Count; i++)
                {
                    Slot<T> slot = new Slot<T>();
                    slot.slotElement = viewElements[i];
                    fieldValue.Add(slot);
                }
            }

        }
    }

    public override void SetSlotGroups(SlotGroup slotGroup)
    {
        if (!slotGroups.Contains(slotGroup))
        {
            slotGroups.Add(slotGroup);
        }
    }

    
    public virtual void SetSlotData(List<Slot<T>> slots, List<T> datas,List<UIData> uIDatas)
    {
        //여기도 데이터 마다 다를듯;
        for(int i = 0; i < datas.Count; i++)
        {
            slots[i].SetData(datas[i],uIDatas[i]);
        }
    }

    public virtual void UPdateSLotData(List<Slot<T>> slots)
    {
       foreach(var slot in slots)
        {
            slot.UPdateSlot();
        }
    }
}
