using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class monsterTower : BaseTank,Broadcast
{

    public float coolTime;
    private float timer;
    public float coolTimeToCheck;
    public rotateObject routate;
    public Transform tower;
    public Transform player = null;
    public Transform[] shootPos;
    public GameObject bullet;
    public float attackRange;

    public float rotateSpeed;

    public LayerMask mask;
    public GameObject healthBar;
    //��ÿؼ�����Ļ���
    GameObject healthCavas;
    public int score = 10;

    private void Start()
    {
        healthCavas = GameObject.Find("monsterHealthShow");
    }
    public override void fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            GameObject obj = Instantiate(bullet, shootPos[i].position, shootPos[i].rotation);
            //����ӵ�������ԣ������˺�
            obj.GetComponent<bulletObj>().setFather(this);
        }
    }


    
    // Update is called once per frame
    void Update()
    {//����������ȴ�¼���������Ҫ�������
        timer += Time.deltaTime;
        coolTimeToCheck += Time.deltaTime;
       
        if (coolTimeToCheck > 1)
        {
            player = checkEnemy();//ÿ����һ���Ƿ������
            coolTimeToCheck = 0;
        }
        if(player != null)
        {
            routate.enabled = false;
            Vector3 dir = player.position - tower.position;
            Quaternion q = Quaternion.LookRotation(dir);
            tower.rotation = Quaternion.Lerp(tower.rotation, q, Time.deltaTime * rotateSpeed);

          
        }
        else
        {
            routate.enabled = true;
        }


        if (timer >=coolTime && player !=null)
        {
            fire();
            timer = 0;
        }
    }


    public Transform checkEnemy()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, attackRange, mask);
        foreach(Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                return collider.gameObject.transform;
            }
        }
        return null;
    }


    //��Ҫ���� ���ֱ�����������ٴ���Ѫ��
    public override void Wond(BaseTank otherTank)
    {
        base.Wond(otherTank);
       if (this.currentHp > 0) 
        {

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
      
    }

    public override void Dead()
    {
        GameManager.Instance.getScore(score);//��ɱmonster���û���
        Destroy(healthBar);
        base.Dead();
       
    }

    public void gameEnd()
    {
        Debug.Log("��Ϸ������");
        this.tower.Rotate(Vector3.up, Time.deltaTime * 200);


    }

    private void OnEnable()
    {
        GameManager.Instance.loginBroad(this);
    }

    private void OnDisable()
    {
        GameManager.Instance.moveBroad(this);
    }

}
