using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public abstract class basePanel : MonoBehaviour
{
    public event UnityAction hidenCallback;
    public bool isShow;
    public CanvasGroup CanvasGroup; //添加过度效果 

    public float smoothSpeed = 10;

    public virtual void Start() //初始化面板
    {
        CanvasGroup = gameObject.GetComponent<CanvasGroup>();
        if (CanvasGroup ==null)
        {
            CanvasGroup =  gameObject.AddComponent<CanvasGroup>();
        }
        init();
    }

    public abstract void init(); //虚函数，进行初始化

   public void showPanel()
    {
        isShow = true;
    }


    public void hidePanel(UnityAction callback)//展示方法
    {
        isShow = false;
        hidenCallback = callback; //回调事件

    }


   public virtual  void Update()
    {
        if (isShow && CanvasGroup.alpha !=1)
        {
            CanvasGroup.alpha += Time.deltaTime * smoothSpeed;
            if (CanvasGroup.alpha >= 1)
            {
                CanvasGroup.alpha = 1;
            }
        }
        else if(!isShow)
        {
            CanvasGroup.alpha -= Time.deltaTime * smoothSpeed;
            if (CanvasGroup.alpha <= 0)
            {
                hidenCallback?.Invoke();
                CanvasGroup.alpha = 0;
            }
        }
    }

}
