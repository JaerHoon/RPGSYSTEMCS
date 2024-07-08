using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharcterData", menuName = "ScriptableObjects/characterData")]
public class CharacterData : DATA
{
    // StatName 타입으로 각 스탯의 이름 필드이름으로 만들고 데이터 타입과
    // 해당 데이터 타입에서 몇번째 인덱스를 가지는지 표시함 (int에서 몇번째 필드인지)
    //예제
    [HideInInspector]
    public int CharacterID;
    [HideInInspector]
    public string CharacterName;
    [HideInInspector]
    public string Description;
    [HideInInspector]
    public Sprite Icon;

    [HideInInspector]
    public Intstat HP;
    [HideInInspector]
    public Intstat MP;
    [HideInInspector]
    public Intstat Exp;
    [HideInInspector]
    public Intstat ATKPow;
    [HideInInspector]
    public Floatstat DFN;


}
