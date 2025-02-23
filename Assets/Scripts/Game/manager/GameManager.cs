using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager :Singleton<GameManager>
{

    public bool isGame;
    public bool playingGame;
    public float leftTimer;

    public RankingData gameData;
    public List<Broadcast> enemy = new List<Broadcast>();
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        gameData = new RankingData();
        gameData.playerName = "临时工小帅";
        
    }


    private void Start()
    {
        inputManager.Instance.inputActions.Ui.showCursor.started += ShowCursor_started;
        UImanager.Instance.showPanel<mainMenuPanel>();
    }

    private void ShowCursor_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        isGame = false;
    }

    public void straGame()
    {
        //开始游戏的接口
        isGame = true;
        playingGame = true;
        UImanager.Instance.showPanel<gameInfoPanel>().AddScore(gameData.score);
      

    }

    public void loginBroad(Broadcast boro)
    {
        enemy.Add(boro);
    }
    public void moveBroad(Broadcast boro)
    {
        enemy.Remove(boro);
    }

    public void BroadPlayerDead()
    {
        for (int i = 0; i < enemy.Count; i++)
        {
            enemy[i].gameEnd();//游戏结束，进行广播
        }
    }


    public void endGame()
    {
        isGame = false;
        playingGame = false;
        //记录数据，存档，记录排名信息，
        GameDataManager.Instance.ranking.rankingDatas.Add(gameData);
        GameDataManager.Instance.saveRankingData();
        Debug.Log(gameData.score);
        Debug.Log(GameDataManager.Instance.ranking.rankingDatas[0].playerName);
        UImanager.Instance.hidePane<gameInfoPanel>();
        UImanager.Instance.hidePane<vectory>();
        gameData.playerName = null;
        gameData.score = 0;
        gameData.passTime = 0;
        leftTimer = 0;



        SceneManager.LoadScene("mainScene");
        UImanager.Instance.showPanel<mainMenuPanel>();

    }

    public void getScore(int score)
    {
        gameData.score += score;
        UImanager.Instance.getPanel<gameInfoPanel>().AddScore(gameData.score);
    }


    private  void Update()
    {


      

        if (isGame && playingGame)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            leftTimer += Time.deltaTime;
            gameData.passTime = leftTimer;
            if (UImanager.Instance.getPanel<gameInfoPanel>())
            {
                UImanager.Instance.getPanel<gameInfoPanel>().updateTimer(leftTimer);
            }
            
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        
    }


}
