using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class inputManager : Singleton<inputManager>

{

    public PlayerControler inputActions; //�°����뷨������
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        inputActions = new PlayerControler();
    }
}
