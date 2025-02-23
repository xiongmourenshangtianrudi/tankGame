using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletObj : MonoBehaviour
{

    public float moveSpeed;
    public int atk;
    public float maxDistance;
    private float currentDistance;
    public BaseTank fatherObj;
    // Start is called before the first frame update

    public GameObject effectObj;


    public void setFather(BaseTank fatherObj)
    {
        this.fatherObj = fatherObj;
    }

    private void FixedUpdate()
    {
        if(fatherObj == null)
        {
            Destroy(gameObject);
        }

        this.transform.Translate(Vector3.forward*moveSpeed*Time.fixedDeltaTime);
        currentDistance += moveSpeed * Time.fixedDeltaTime;
        if (currentDistance >= maxDistance)
        {
            Destroy(this.gameObject);
            //特效啥的
        }
    }

    //触发函数，造成伤害啥的



    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(fatherObj.tag) )
        {
            if (other.gameObject.GetComponent<bulletObj>() != null)
            {
                if(other.GetComponent<bulletObj>().fatherObj!= this.fatherObj)//判断是否是子弹类型
                {
                    Destroy(this.gameObject);
                    Instantiate(effectObj, this.transform.position, Quaternion.identity);
                }
            }
            else
            {
                if (other.gameObject.GetComponent<BaseTank>() != null)
                {
                    other.gameObject.GetComponent<BaseTank>().Wond(fatherObj);
                }
                Destroy(this.gameObject);
                Instantiate(effectObj, this.transform.position, Quaternion.identity);
            }
           
        }
       
    }


}
