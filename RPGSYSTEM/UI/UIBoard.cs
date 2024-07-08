using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class UIBoard : MonoBehaviour
{
    public ViewElement boardInfo = new ViewElement();
    

    public virtual void SetBoardComponent()
    {

        List<UIComponents> myComponents = Utility.FindAllComponentsInChildren<UIComponents>(this.transform)
                                        .Where(co => co.hierarchyType == UIComponents.HierarchyType.BoardInfo).ToList();

        foreach (UIComponents com in myComponents)
        {
            switch (com.componentType)
            {
                case UIComponents.ComponentType.Image:
                    Image image = com.GetComponent<Image>();
                    boardInfo.ImageComponents.Add(com.KeyName, image);
                    break;
                case UIComponents.ComponentType.TextMeshProUGUI:
                    TextMeshProUGUI text = com.GetComponent<TextMeshProUGUI>();
                    boardInfo.textComopnent.Add(com.KeyName, text);
                    break;
                case UIComponents.ComponentType.Slider:
                    Slider slider = com.GetComponent<Slider>();
                    boardInfo.sliderComponent.Add(com.KeyName, slider);
                    break;
            }
        }
    }

    public virtual void SetSlots(SlotGroup slotGroup)
    {

    }

    public virtual void SetSlotGroups(SlotGroup slotGroup)
    {

    }

  

    public virtual void SetKeyName()
    {
        //각 메니저에서 키네임을 받아온다
        //아니면 그냥 유틸리티에 있는 겟필드 함수를 이용해도 된다
    }

    public virtual void GetUIdata()
    {

    }
}
