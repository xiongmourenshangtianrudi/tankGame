using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenuPanel : basePanel
{
    public Button stratGame;
    public Button optionButton;
    public Button quitGame;
    public Button ranking;
    public override void init()
    {
        //监听按钮

        stratGame.onClick.AddListener(() =>
        {
            //开始游戏 切换场景，
            SceneManager.LoadScene("level1");
            UImanager.Instance.hidePane<mainMenuPanel>();
            GameManager.Instance.straGame();//开始游戏
        });

        optionButton.onClick.AddListener(() =>
        {
            //打开option菜单
            UImanager.Instance.showPanel<optionPanel>();
            //UImanager.Instance.hidePane<mainMenuPanel>();
        });
        quitGame.onClick.AddListener(() =>
        {
            Application.Quit();
        });


        ranking.onClick.AddListener(() =>{
            UImanager.Instance.showPanel<RankingListPanel>();
            UImanager.Instance.hidePane<mainMenuPanel>();
        });
    }

  
}


