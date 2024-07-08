using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class SlotView : MonoBehaviour
{
    public UIBoard myBoard;
    public ViewElement SlotComponents = new ViewElement();
    public int SlotIndex;
    List<UIComponents> components = new List<UIComponents>();


    public virtual void GetSlotComponent()
    {
        components = Utility.FindAllComponentsInChildren<UIComponents>(this.transform)
                                    .Where(co => co.hierarchyType == UIComponents.HierarchyType.Slot).ToList();
        SlotComponents.ImageComponents.Clear();
        SlotComponents.sliderComponent.Clear();
        SlotComponents.textComopnent.Clear();
        foreach (UIComponents com in components)
        {

            switch (com.componentType)
            {
                case UIComponents.ComponentType.Image:
                    Image image = com.GetComponent<Image>();
                    SlotComponents.ImageComponents.Add(com.KeyName, image);
                    break;
                case UIComponents.ComponentType.TextMeshProUGUI:
                    TextMeshProUGUI text = com.GetComponent<TextMeshProUGUI>();
                    SlotComponents.textComopnent.Add(com.KeyName, text);
                    break;
                case UIComponents.ComponentType.Slider:
                    Slider slider = com.GetComponent<Slider>();
                    SlotComponents.sliderComponent.Add(com.KeyName, slider);
                    break;
            }
        }
    }

}
