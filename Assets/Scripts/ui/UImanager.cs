using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UImanager 
{
    private static UImanager instance = new UImanager();
    public static UImanager Instance => instance;

    private Dictionary<string, basePanel> panels = new Dictionary<string, basePanel>(); //����������

    private Transform Cavastransform;
    private UImanager() //˽�л����캯���������ⲿʵ����
    {
        Cavastransform = GameObject.Find("Canvas").transform; //��ȡCanvs����
        
       GameObject.DontDestroyOnLoad(Cavastransform.gameObject);//��֤�����ٶ���
    }
    //��ʾui
    public T showPanel<T>()where T : basePanel //ͨ������ȷ������
    {
        //��ȡ����
        string PanelName = typeof(T).Name;
        if (panels.ContainsKey(PanelName))
        {
            return panels[PanelName] as T;
        }


        GameObject panelObject = GameObject.Instantiate(Resources.Load<GameObject>("UI/" + PanelName));//�ֶ�����һ��������
        panelObject.transform.SetParent(Cavastransform, false);
        T panel = panelObject.GetComponent<T>(); //�����������
        panel.showPanel(); //չʾui
        panels.Add(PanelName, panel); //���뵽ui�б�
        return panel ;
    }


    //����ui
    public void hidePane<T>(bool isFade = true) where T : basePanel
    {
        string panelName = typeof(T).Name;
        if(panelName == "gameInfoPanel")
        {
            Debug.Log(typeof(T).Name + panels[panelName].gameObject.name);
        }
        if (panels.ContainsKey(panelName))
        {
            if (isFade)
            {
                panels[panelName].hidePanel(() =>
                {
                    //����������
                    
                    GameObject.Destroy(panels[panelName].gameObject);
                    panels.Remove(panelName);
                });


            }
            else{
                GameObject.Destroy(panels[panelName].gameObject);
                panels.Remove(panelName);
            }
        }
        
    }

    public T getPanel<T>()where T:basePanel
    {
        string panelName = typeof(T).Name;
        if (panels.ContainsKey(panelName))
        {
            return panels[panelName] as T;
        }
        else
        {
            return null;
        }
    }



}
