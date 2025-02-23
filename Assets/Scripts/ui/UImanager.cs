using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UImanager 
{
    private static UImanager instance = new UImanager();
    public static UImanager Instance => instance;

    private Dictionary<string, basePanel> panels = new Dictionary<string, basePanel>(); //保存面板对象

    private Transform Cavastransform;
    private UImanager() //私有化构造函数，避免外部实例化
    {
        Cavastransform = GameObject.Find("Canvas").transform; //获取Canvs对象
        
       GameObject.DontDestroyOnLoad(Cavastransform.gameObject);//保证不销毁对象
    }
    //显示ui
    public T showPanel<T>()where T : basePanel //通过泛型确定名字
    {
        //获取名字
        string PanelName = typeof(T).Name;
        if (panels.ContainsKey(PanelName))
        {
            return panels[PanelName] as T;
        }


        GameObject panelObject = GameObject.Instantiate(Resources.Load<GameObject>("UI/" + PanelName));//手动创建一个面板对象
        panelObject.transform.SetParent(Cavastransform, false);
        T panel = panelObject.GetComponent<T>(); //返回组件对象
        panel.showPanel(); //展示ui
        panels.Add(PanelName, panel); //加入到ui列表
        return panel ;
    }


    //销毁ui
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
                    //淡出后销毁
                    
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
