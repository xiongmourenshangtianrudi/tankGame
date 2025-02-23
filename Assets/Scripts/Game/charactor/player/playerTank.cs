using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerTank : BaseTank
{
    public Rigidbody body;
    public Vector2 dir = Vector2.zero;
 
    public Transform head;
    public Transform wepontrans;
    public GameObject weponContent;
    public weaponObj weaponObj;
 
    
    public float fireCoolTime =2;
    public float timer;
    public bool canFire;
    public GameObject getWeaponEffect;

    
    public override void fire()
    {
        //开火时间
        if(weaponObj != null)
        {
            weaponObj.fire();
            Debug.Log("fier");
        }
        else
        {
            //Debug.Log("当前没有武器");
        }
       
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject weaPon = null;
        inputManager.Instance.inputActions.gamePlay.fire.started += tankeFire;


        if (weponContent.transform.childCount > 0)
        {
            weaPon = weponContent.transform.GetChild(0).gameObject;
        }
        
        if(weaPon != null)
        {
            weaponObj = weaPon.GetComponent<weaponObj>();
        }
    }

    private void tankeFire(InputAction.CallbackContext context)
    {
        
        fire();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    public void move()
    {
        //控制坦克的移动转向
        dir = inputManager.Instance.inputActions.gamePlay.move.ReadValue<Vector2>();
        if(dir.y != 0)
        {
            body.velocity = transform.forward * moveSpeed * Time.fixedDeltaTime *dir.y ;//移动坦克，
        }
        else
        {
            //停止移动
            body.velocity = new Vector3(0, 0, 0);
        }

        if (dir.x != 0)
        {
            transform.Rotate(0f, dir.x * roundSpeed * Time.fixedDeltaTime, 0);
        }
        
       


    }

    public void towerRotate(Quaternion q) //传递两个参数即可
    {

        //Debug.Log(mouseDir);
        //计算旋转角度
        //创建一个射线
        float y = q.eulerAngles.y;
        float x = q.eulerAngles.x;
        Debug.Log("x" + x);
        //x = Mathf.Clamp(x, -10, 2);
        head.rotation = Quaternion.Lerp(head.rotation,Quaternion.Euler(0,y,0), headRoundSpeed * Time.deltaTime);
        wepontrans.rotation = Quaternion.Lerp(wepontrans.rotation, Quaternion.Euler(x, wepontrans.eulerAngles.y, wepontrans.eulerAngles.z), headRoundSpeed * Time.deltaTime);
    }


    //DAMAGE
    public override void Dead()
    {
        base.Dead();
        GameManager.Instance.BroadPlayerDead();//广播，告知玩家死亡
        UImanager.Instance.showPanel<vectory>().setInfo("游戏失败", "游戏失败，你的成绩是", GameManager.Instance.gameData.score);
       
    }

    public override void Wond(BaseTank otherTank)
    {
        base.Wond(otherTank);
        UImanager.Instance.getPanel<gameInfoPanel>().updateHealhtBar(maxHp,currentHp);

    }

    private void OnEnable()
    {

        inputManager.Instance.inputActions.Enable();
    }
    private void OnDisable()
    {
        inputManager.Instance.inputActions.Disable();
    }
    //切换武器
    public void changeWeaPon(GameObject newWeapon) //个gameManage调用的
    {


        Instantiate(getWeaponEffect, transform.position, Quaternion.identity);//播放拾取特效

        //切换模型
        if (weaponObj != null)
        {
            Destroy(weaponObj.gameObject);
            weaponObj = null;
        }
       
        GameObject newWeaPon = Instantiate(newWeapon);
        newWeaPon.transform.SetParent(weponContent.transform, false);
        weaponObj = newWeaPon.GetComponent<weaponObj>();
        weaponObj.setFather(this);
    }




}
