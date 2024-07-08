using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerableCharacter : MonoBehaviour
{
    public int InGameChracterID;
    protected Character me;
    protected SliderStat HP_Slider;
    

    public virtual void Init()
    {
      me = CharacterManager.Instance.inBattleCharacters[InGameChracterID];
      HP_Slider = new SliderStat("HP_Slider", Enums.StatType.Int , me.HP.GetEquipedValue(), me.HP.GetEquipedValue());
    }

    public virtual void ChangeStat(Intstat stat,int amount)
    {
        stat.Settempstat(amount);
    }

    public virtual void ChangeStat(Floatstat stat, float amount)
    {
        stat.Settempstat(amount);
    }

    public void RestoreStat(Intstat stat, int amount)
    {
        stat.Restoretmepstat(amount);
    }

    public void RestoreStat(Floatstat stat, float amount)
    {
        stat.Restoretmepstat(amount);
    }

    public virtual void ChangeHP(int amount)
    {
        HP_Slider.curValue -= amount;
        if(HP_Slider.curValue <= 0)
        {
            Die();
        }
    }

    public virtual void ChangeHP(float amount)
    {
        HP_Slider.curValue -= amount;
        if (HP_Slider.curValue <= 0)
        {
            Die();
        }
    }


    public virtual void Die()
    {

    }

    public virtual void OnSkill(Skill skill)
    {

    }
}
