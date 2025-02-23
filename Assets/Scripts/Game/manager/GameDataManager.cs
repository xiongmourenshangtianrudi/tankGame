using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 游戏数据管理类
/// </summary>
public class GameDataManager : Singleton<GameDataManager>
{
    public audioData audio;
    //读取数据方法
    public Ranklist ranking;
    protected override void Awake()
    {
        base.Awake();
        ReadData();
    }
    public void  ReadData()//读取游戏数据
    {
        audio = PlayerPrefsDataMgr.Instance.LoadData(typeof(audioData), "audio") as audioData;
        //如果第一次进入游戏，没有数据，则获得的时默认值。
        if (!audio.isNotFirstLoadGame)
        {
            audio.onVfx = true;
            audio.onMusic = true;
            audio.musicVolume = 1;
            audio.vfxVolume = 1;
            audio.isNotFirstLoadGame = true;
            PlayerPrefsDataMgr.Instance.SaveData(audio, "audio");
        }
        //没错存储排行数据时，先精选排序

        
        ranking = PlayerPrefsDataMgr.Instance.LoadData(typeof(Ranklist), "ranking") as Ranklist;//返回一个排名数组
        //进行排名
        for (int i = 0; i < ranking.rankingDatas.Count; i++)
        {
            print(ranking.rankingDatas[i].score);
        }

    }

    public void saveRankingData()
    {
        sortList();
        
        PlayerPrefsDataMgr.Instance.SaveData(ranking, "ranking");
        Debug.Log("数据已经保存");
    }




    public void SaveGameData()
    {
        //调整后保存数据

        PlayerPrefsDataMgr.Instance.SaveData(audio, "audio");
        saveRankingData();
    }
    
    //存储数据

    public void sortList() //对数组进行排序
    {
        ranking.rankingDatas.Sort((a,b) =>
        {
            
            return a.score > b.score ? -1 : 1;
        });
    }






}
