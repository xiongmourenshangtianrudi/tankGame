using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapCameraControler : MonoBehaviour
{
    public Transform targetTransform;
    public float H = 27;
    public Vector3 minPostion;
    public Vector3 maxPostion;

    private void Start()
    {
        targetTransform = GameObject.Find("playerTank").transform;//在场景中获得玩家
       
       
    }
    private void LateUpdate()
    {
        if (targetTransform != null)
        {
            float x = Mathf.Clamp(targetTransform.position.x, minPostion.x, maxPostion.z);
            float z = Mathf.Clamp(targetTransform.position.z, minPostion.z, maxPostion.z);
            //限制地图的移动
            this.transform.position = new Vector3(x, H, z);

        }
    }

}
