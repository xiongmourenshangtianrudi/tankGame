using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class vectory : basePanel
{
    public Button yes;
    public Button reStart;
    public Text info;
    public Text head;
    public InputField input;


    public override void init()
    {
        GameManager.Instance.isGame = false;
        //实现功能监听
        inputManager.Instance.inputActions.Disable(); //关闭控制器
        yes.onClick.AddListener(() =>
        {
            //保存数据
            //返回到主界面
            GameManager.Instance.gameData.playerName = input.text;
            GameManager.Instance.endGame();
            SceneManager.LoadScene("mainScene");
           
        });
        reStart.onClick.AddListener(() =>
        {
            //保存数据，不返回主界面
            //重新开始游戏
            UImanager.Instance.hidePane<vectory>();
            SceneManager.LoadScene("level1");
        });
    }

    public void setInfo(string headInfo,string text,int score)
    {
        head.text = headInfo;
        info.text = text + score;
    }

    private void OnDestroy()
    {
        inputManager.Instance.inputActions.Enable(); //开启控制器
    }

}

  

   

