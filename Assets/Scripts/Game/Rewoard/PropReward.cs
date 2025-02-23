using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum propTyp
{
    Hp,
    MaxHp,
    Def,
    Atk,
}

public class PropReward : MonoBehaviour
{
    public propTyp propType = propTyp.Hp;
    public GameObject effect;


    public int changeValue;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //TODO 调用对象身上的修改属性的方式
            playerTank tank = other.gameObject.GetComponent<playerTank>();
            switch (propType)
            {
                case propTyp.Hp:
                    tank.currentHp += changeValue;
                    if(tank.currentHp > tank.maxHp)
                    {
                        tank.currentHp = tank.maxHp;
                    }
                    UImanager.Instance.getPanel<gameInfoPanel>().updateHealhtBar(tank.maxHp, tank.currentHp);
                    break;
                case propTyp.Def:
                    tank.def += changeValue;
                    break;
                case propTyp.Atk:
                    tank.atk += changeValue;
                    break;
                case propTyp.MaxHp:
                    tank.maxHp += changeValue;
                    UImanager.Instance.getPanel<gameInfoPanel>().updateHealhtBar(tank.maxHp,tank.currentHp);
                    break;
            
            }
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);//销毁
        }
    }

}
