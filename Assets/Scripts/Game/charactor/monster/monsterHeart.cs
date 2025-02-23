using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterHeart : BaseTank
{
    public GameObject healthBar;
    //��ÿؼ�����Ļ���
    GameObject healthCavas;
    public override void fire()
    {
        
    }
    public override void Wond(BaseTank otherTank)
    {
        base.Wond(otherTank);
        if (healthBar != null)
        {
            healthBar.GetComponent<monsterHealth>().updateHealhtBar(maxHp, currentHp);
            healthBar.transform.position = transform.position + new Vector3(0, 2, 0);
        }
        else
        {
            healthBar = Instantiate(Resources.Load<GameObject>("UI/helathback"), transform.position + new Vector3(0, 2, 0), Quaternion.identity);
            healthBar.transform.SetParent(healthCavas.transform);
            healthBar.GetComponent<monsterHealth>().updateHealhtBar(maxHp, currentHp);
        }
    }


    public override void Dead()
    {
        base.Dead();
        GameManager.Instance.isGame = false;
        UImanager.Instance.showPanel<vectory>().setInfo("��Ϸʤ��","��ɹ��Ļ����˺���",GameManager.Instance.gameData.score);

    }
}
