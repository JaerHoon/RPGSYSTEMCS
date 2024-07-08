using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff 
{
    public Enums.BuffDebuffType buffDebuffType;
    public float duration; //버프 시간 
    public float checkduration; //도트 시간
    public float buffPow;

    public Buff(float time, float checktime, float pow)
    {
        duration = time;
        checkduration = checktime;
        buffPow = pow;
    }

    public virtual void OnBuff()
    {

    }

    public virtual void CheckBuff()
    {

    }

    public virtual void OffBuff()
    {

    }

}
