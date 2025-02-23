using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamaraControl : MonoBehaviour,Broadcast
{
    public GameObject targetPos;//�ű��������������Ŀ����ת
    public Transform camaraT;//��������ת������x����ת

    public Vector3 hight;
    public bool isGame = true;

    public float maxRayDistance;
    Vector3 towerDir = Vector3.zero;

    public float distance;
    public float smooth = 10;
    private Vector3 temp;
    float horAngle = 0;
    float verAngle = 0;

    public LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.isGame)
        {
            Vector2 mouseDelt = Mouse.current.delta.ReadValue();//����λ����
                                                                //������ת�Ƕ�
            horAngle += mouseDelt.x * smooth * Time.deltaTime;//ˮƽ
            verAngle -= mouseDelt.y * smooth * Time.deltaTime;
            verAngle = angleClamp(verAngle, -10, 45);
            Quaternion quaternion = Quaternion.Euler(verAngle, horAngle, 0);
            

            temp = new Vector3(0, 0, distance);
            if (targetPos != null)
            {
                Vector3 descripPostion = quaternion * temp + targetPos.transform.position+ hight; //����ƫ��ֵ

                transform.rotation = quaternion;
                transform.position = descripPostion;
                

            }
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxRayDistance))
            {
                Debug.Log(hit.point);
                // hit.point ��Ŀ�����λ��
                towerDir = hit.point - targetPos.GetComponent<playerTank>().weponContent.transform.position;
                Debug.DrawLine(targetPos.GetComponent<playerTank>().weponContent.transform.position, hit.point, Color.blue);
            }
            else
            {
                Vector3 endPoint = ray.origin + ray.direction.normalized * maxRayDistance;
                Debug.Log("rayDIR" + ray.direction);
                towerDir = endPoint - targetPos.GetComponent<playerTank>().weponContent.transform.position;
                Debug.DrawLine(targetPos.GetComponent<playerTank>().weponContent.transform.position, endPoint, Color.blue);
            }
            print(towerDir);
            Quaternion q = Quaternion.LookRotation(towerDir);
        

            targetPos.gameObject.GetComponent<playerTank>().towerRotate(q);
          






   

        }



    }

    
    public float angleClamp(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }

    private void OnEnable()
    {
        GameManager.Instance.loginBroad(this);
    }
    private void OnDisable()
    {
        GameManager.Instance.moveBroad(this);
    }
    public void gameEnd()
    {
        this.isGame = false;
      
    }
}
