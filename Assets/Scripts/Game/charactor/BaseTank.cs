using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class BaseTank : MonoBehaviour
{
    [Header("Properties")]
    
    public int atk; 
    public int def;
    public int maxHp;
    public int currentHp;
    [Header("speed")]
    public float moveSpeed = 10;
    public float roundSpeed = 100;
    public float headRoundSpeed = 100;

    public GameObject destroyEffect;


    /// <summary>
    /// ������д������Ϊ
    /// </summary>
    public abstract void fire(); //�����࣬������д

    public virtual void Wond(BaseTank otherTank)
    {
        int damage = otherTank.atk - this.def;
        currentHp -= Mathf.Max(damage, 1); //�����˺�

        //���Ѫ��С��0������
        if (currentHp <= 0)
        {
            this.currentHp = 0;
            Dead();
        }


    }


    public virtual void Dead()
    {
        this.gameObject.SetActive(false);

       GameObject eff =  Instantiate(destroyEffect, this.gameObject.transform.position, Quaternion.identity);

        //������������������
        Destroy(this.gameObject,3);
    }

}
