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
    public CanvasGroup CanvasGroup; //��ӹ���Ч�� 

    public float smoothSpeed = 10;

    public virtual void Start() //��ʼ�����
    {
        CanvasGroup = gameObject.GetComponent<CanvasGroup>();
        if (CanvasGroup ==null)
        {
            CanvasGroup =  gameObject.AddComponent<CanvasGroup>();
        }
        init();
    }

    public abstract void init(); //�麯�������г�ʼ��

   public void showPanel()
    {
        isShow = true;
    }


    public void hidePanel(UnityAction callback)//չʾ����
    {
        isShow = false;
        hidenCallback = callback; //�ص��¼�

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
