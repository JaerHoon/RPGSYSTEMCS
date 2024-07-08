using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerableCharacterBattle : MonoBehaviour
{
    protected virtual (int pow, bool IsCrt) Cal_AttackPow(int skillpow)
    {
        int pow = 0;
        bool IsCrt = false;

        return (pow, IsCrt);
    }
    protected virtual (float pow, bool IsCrt) Cal_AttackPow(float skillpow)
    {
        float pow = 0;
        bool IsCrt = false;

        return (pow, IsCrt);
    }

    public virtual void OnAttack(PlayerableCharacterBattle character, int skillpow)
    {

        var result = Cal_AttackPow(skillpow);

        int atkpow = result.pow;
        bool IsCrt = result.IsCrt;

        character.OnDamage(atkpow, IsCrt);

    }

    public virtual void OnAttack(PlayerableCharacterBattle character, float skillpow)
    {

        var result = Cal_AttackPow(skillpow);

        float atkpow = result.pow;
        bool IsCrt = result.IsCrt;

        character.OnDamage(atkpow, IsCrt);

    }

    public virtual void OnDamage(int atkpow, bool IsCrt)
    {
      
    }

    public virtual void OnDamage(float atkpow, bool IsCrt)
    {

    }


    public virtual void ContinuosDamage(int pow, float duration, float damageTime)
    {
       //지속데미지 처리 함수
    }

    public virtual void UIDamage(int pow, bool IsCrt)
    {
        //데미지 이펙트 및 후처리 함수
    }
}
