using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot<T> 
{
    public ViewElement slotElement = new ViewElement();
    public T data;
    public UIData uIdata;

    public virtual void SetData(T data, UIData uIData)
    {
        this.data = data;
        this.uIdata = uIData;
        UPdateSlot();
    }

    public virtual void UPdateSlot()
    {
        SetValue(uIdata.imageValue);
        SetValue(uIdata.intValue);
        SetValue(uIdata.floatValue);
        SetValue(uIdata.stringValue);
        SetValue(uIdata.sliderValue);
        SetValue(uIdata.intstatvalue);
        SetValue(uIdata.floatstatvalue);
    }

    public virtual void SetValue(Dictionary<string, Intstat> intstatValue)
    {
        foreach(var val in intstatValue)
        {
            slotElement.textComopnent[val.Key].text = val.Value.GetBasicValue().ToString();
            slotElement.textComopnent[val.Key + "equiped"].text = val.Value.GetEquipedValue().ToString();
            slotElement.textComopnent[val.Key + "temp"].text = val.Value.GetAllValue().ToString();
        }
    }

    public virtual void SetValue(Dictionary<string, Floatstat> floatstatValue)
    {
        foreach (var val in floatstatValue)
        {
            slotElement.textComopnent[val.Key].text = val.Value.GetBasicValue().ToString();
            slotElement.textComopnent[val.Key + "(equipment)"].text = val.Value.GetEquipedValue().ToString();
            slotElement.textComopnent[val.Key + "(All)"].text = val.Value.GetAllValue().ToString();
        }
    }

    public virtual void SetValue(Dictionary<string, SliderStat> slidervalue)
    {
        foreach(var val in slidervalue)
        {
            if(val.Value.statType == Enums.StatType.Int)
            {
                slotElement.sliderComponent[val.Key].maxValue = val.Value.GetIntAmount()[0];
                slotElement.sliderComponent[val.Key].value = val.Value.GetIntAmount()[1];

            }
            else
            {
                slotElement.sliderComponent[val.Key].maxValue = val.Value.GetfloatAmount()[0];
                slotElement.sliderComponent[val.Key].value = val.Value.GetfloatAmount()[1];
            }
        }
    }

    public virtual void SetValue(Dictionary<string, Sprite> imageValue)
    {
        foreach(var val in imageValue)
        {
            slotElement.ImageComponents[val.Key].sprite = val.Value;
        }
    }
    public virtual void SetValue(Dictionary<string, int> intValue)
    {
        foreach (var val in intValue)
        {
            slotElement.textComopnent[val.Key].text = val.Value.ToString();
           
        }
    }

    public virtual void SetValue(Dictionary<string, float> floatValue)
    {
        foreach (var val in floatValue)
        {
            slotElement.textComopnent[val.Key].text = val.Value.ToString();

        }
    }


    public virtual void SetValue(Dictionary<string, string> stringValue)
    {
        foreach (var val in stringValue)
        {
            slotElement.textComopnent[val.Key].text = val.Value;

        }
    }

   
}
public class ViewElement
{
    public Dictionary<string, Image> ImageComponents = new Dictionary<string, Image>();
    public Dictionary<string, TextMeshProUGUI> textComopnent = new Dictionary<string, TextMeshProUGUI>();
    public Dictionary<string, Slider> sliderComponent = new Dictionary<string, Slider>();
}