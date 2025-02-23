using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notice : MonoBehaviour
{
    public Camera MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = MainCamera.transform.position - transform.position;
        Vector3 back = -dir;
        Quaternion q = Quaternion.LookRotation(back);
        transform.rotation = q;
    }
}
