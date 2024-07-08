using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerableChracterBuffDebuff : MonoBehaviour
{
    [SerializeField]
    protected List<Buff> buffs = new List<Buff>();
    protected List<Buff> Ativebuffs = new List<Buff>();
    protected List<Buff> AtiveDebuffs = new List<Buff>();

    protected WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

    public virtual void OnBuff(Buff buff)
    {
        StartCoroutine(buffing(buff));
    }

    protected virtual IEnumerator buffing(Buff buff)
    {
        buff.OnBuff();
        OnUI(buff);
        float time = 0;
        float nextCheckTime = buff.checkduration;


        while (time < buff.duration)
        {
            time += Time.deltaTime;

            if (time >= nextCheckTime)
            {
                buff.CheckBuff();
                UpDateUI(buff);
                nextCheckTime += buff.checkduration;
            }

            yield return waitForFixedUpdate;
        }

        buff.OffBuff();
        
        OffUI(buff);
    }

    protected virtual void OnUI(Buff buff)
    {
        // UI활성화 
        // UIBuffDebuffs[(int)buffDebuff.buffDebuffType].SetActive(true);
    }

    protected virtual void UpDateUI(Buff buff)
    {
        //지속데미지 처럼 중간 중간 바꿔줘야 하는 UI 이펙트
    }

    protected virtual void OffUI(Buff buff)
    {
        // UI비활성화 
        // UIBuffDebuffs[(int)buffDebuff.buffDebuffType].SetActive(false);
    }
}

