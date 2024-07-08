using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class CharacterManager : Manager<CharacterManager>
{
    [SerializeField]
    List<CharacterData> characterDatas = new List<CharacterData>();
    protected List<Character> characters = new List<Character>();
    protected List<Character> activeCharacters = new List<Character>();
    public List<Character> inBattleCharacters = new List<Character>();
    public List<string> KeyName = new List<string>();

    protected virtual void Init()
    {
        List<List<Skill>> skills = SkillManager.Instance.Getcharacterskills();
            
        for (int i = 0; i < characterDatas.Count; i++)
        {
            Character chars = new Character(characterDatas[i]);
            chars.SetSkill(skills[i]);
            characters.Add(chars);
        }

        characters = characters.OrderBy(ch => ch.CharacterID).ToList();

    }

    public virtual void GetCharacter(int Index)
    {
        activeCharacters.Add(characters[Index]);
        activeCharacters = activeCharacters.OrderBy(ch => ch.CharacterID).ToList();
    }

    public virtual void EquipCharacter(int slotnum, int characterNum)
    {
        for (int i = 0; i < inBattleCharacters.Count; i++)
        {
            if (i != slotnum)
            {
                if (inBattleCharacters[i] == characters[characterNum])
                {
                    inBattleCharacters[i] = null;
                }
            }
            else
            {
                inBattleCharacters[i] = characters[characterNum];
            }
        }
    }

    public virtual List<string> GetKeyName()
    {
        KeyName.AddRange(Utility.Getfields(typeof(CharacterData)));
        return KeyName;
    }

    public virtual List<UIData> GetUIDatas(List<Character> chraLsit)
    {
        List<UIData> uIdatas = new List<UIData>();
        foreach(var C in chraLsit)
        {
            uIdatas.Add(C.GetUIdata());
        }

        return uIdatas;
    }
        
}
