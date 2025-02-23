using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class quitGamePanel : basePanel
{
    public Button closePanel;
    public Button quitYes;
    public Button quitNo;
    public Animator animator;


    public override void init()
    {
        animator = GetComponent<Animator>();

        closePanel.onClick.AddListener(() =>
        {
            GameManager.Instance.endGame();
            UImanager.Instance.hidePane<quitGamePanel>();
            animator.SetBool("close", true);
        });
        quitYes.onClick.AddListener(() =>
        {
            UImanager.Instance.hidePane<gameInfoPanel>();
            UImanager.Instance.hidePane<quitGamePanel>();
            
            SceneManager.LoadScene("mainScene");
            UImanager.Instance.showPanel<mainMenuPanel>();
        });

        quitNo.onClick.AddListener(() =>
        {
            UImanager.Instance.hidePane<quitGamePanel>();
            animator.SetBool("close", true);
        });

       


    }

   
}
