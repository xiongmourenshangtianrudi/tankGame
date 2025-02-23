using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ��Ϸ���ݹ�����
/// </summary>
public class GameDataManager : Singleton<GameDataManager>
{
    public audioData audio;
    //��ȡ���ݷ���
    public Ranklist ranking;
    protected override void Awake()
    {
        base.Awake();
        ReadData();
    }
    public void  ReadData()//��ȡ��Ϸ����
    {
        audio = PlayerPrefsDataMgr.Instance.LoadData(typeof(audioData), "audio") as audioData;
        //�����һ�ν�����Ϸ��û�����ݣ����õ�ʱĬ��ֵ��
        if (!audio.isNotFirstLoadGame)
        {
            audio.onVfx = true;
            audio.onMusic = true;
            audio.musicVolume = 1;
            audio.vfxVolume = 1;
            audio.isNotFirstLoadGame = true;
            PlayerPrefsDataMgr.Instance.SaveData(audio, "audio");
        }
        //û��洢��������ʱ���Ⱦ�ѡ����

        
        ranking = PlayerPrefsDataMgr.Instance.LoadData(typeof(Ranklist), "ranking") as Ranklist;//����һ����������
        //��������
        for (int i = 0; i < ranking.rankingDatas.Count; i++)
        {
            print(ranking.rankingDatas[i].score);
        }

    }

    public void saveRankingData()
    {
        sortList();
        
        PlayerPrefsDataMgr.Instance.SaveData(ranking, "ranking");
        Debug.Log("�����Ѿ�����");
    }




    public void SaveGameData()
    {
        //�����󱣴�����

        PlayerPrefsDataMgr.Instance.SaveData(audio, "audio");
        saveRankingData();
    }
    
    //�洢����

    public void sortList() //�������������
    {
        ranking.rankingDatas.Sort((a,b) =>
        {
            
            return a.score > b.score ? -1 : 1;
        });
    }






}
