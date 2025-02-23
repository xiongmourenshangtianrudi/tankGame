using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public enum state
{
    attack,
    fix,
    patrol,
    wait
}


public class monsterTank : BaseTank,Broadcast
{
    public Transform minRange;
    public Transform maxRange;//Ѳ�߷�Χ
    public NavMeshAgent navigation;

    public Transform[] shootPos;
    public GameObject bullet;
    public Transform player;
    public Transform tower;


    public float coolTime;
    private float timer;
    public float waitTime;
    private float currentWaitTime;
    public float coolTimeToCheck;
    public rotateObject routate;
    public float rotateSpeed;

    public float attackRange;

    public GameObject healthBar;

    Vector3 target;
    Rigidbody rb;
    public state state = state.wait;

    public LayerMask mask;

    public int score = 10;//��ɱ��õ��Ļ���


    //��ÿؼ�����Ļ���
    GameObject healthCavas;


    public override void fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            GameObject obj = Instantiate(bullet, shootPos[i].position, shootPos[i].rotation);
            //����ӵ�������ԣ������˺�
            obj.GetComponent<bulletObj>().setFather(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        healthCavas = GameObject.Find("monsterHealthShow");

       rb = gameObject.GetComponent<Rigidbody>();
        if(rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
    }

    //ai�ƶ�
    public bool tankMove(Vector3 target)
    {
        navigation.isStopped = false;
        navigation.SetDestination(target);
        if (Vector3.Distance(gameObject.transform.position, target) < 1f)
        {
            return true;

        }
        return false;
    }

    private void OnEnable()
    {
        GameManager.Instance.loginBroad(this);
    }

    private void OnDisable()
    {
        GameManager.Instance.moveBroad(this);
    }


    //ai

    // Update is called once per frame
    void Update()
    {
       
        coolTimeToCheck += Time.deltaTime;
        timer += Time.deltaTime;
        if (timer > coolTime) timer = coolTime;
        if (coolTimeToCheck > 1)
        {
            player = checkEnemy();//ÿ����һ���Ƿ������
            coolTimeToCheck = 0;
        }
       

        //Ѫ���ף�����ҳ�̣�Ȼ��ը��


        //����Э���״̬��
        switch (state)
        {
            case state.patrol:
                patrol();
                break;
            case state.wait:
                wait();
                break;

            case state.attack:
                attack();
                break;
        }
    }

    public void patrol()
    {
        bool b =tankMove(target);//����ƶ�
        if (player != null && timer>=coolTime)
        {
            Vector3 dir = player.position - tower.position;
            Quaternion q = Quaternion.LookRotation(dir);
            tower.rotation = Quaternion.Lerp(tower.rotation, q, Time.deltaTime * rotateSpeed);
            state = state.attack;
        }
        if (b)
        {
            state = state.wait;
        }
        
    }

    public void attack()
    {
        //�����ӵ���Ȼ��ת��proto

        fire();
        timer = 0;
        state = state.wait;
    }


    public void fiexd()
    {

    }

    public void wait()
    {

        if (player != null)
        {
            Quaternion q = Quaternion.AngleAxis(Random.Range(0, 180), Vector3.up);//����һ����ת��Ԫ������ʾ��ĳ������ת���ٶ�
            target = player.position + q * (player.forward*10);//��ʾ��ĳ��������q�����Ԫ��������ת
            state = state.patrol;
            return;
        }


        if(this.currentHp <maxHp * 0.4)
        {
            Quaternion q = Quaternion.AngleAxis(Random.Range(0, 180), Vector3.up);//����һ����ת��Ԫ������ʾ��ĳ������ת���ٶ�
            target = player.position + q * (player.forward * 100);//��ʾ��ĳ��������q�����Ԫ��������ת
            state = state.patrol;
        }


        if (currentWaitTime >= waitTime)
        {
          
           
                target = new Vector3(Random.Range(minRange.position.x, maxRange.position.x), 0, Random.Range(minRange.position.z, maxRange.position.z));
                state = state.patrol;
                currentWaitTime = 0;
           
           
        }
        currentWaitTime += Time.deltaTime;


    }

    


    public Transform checkEnemy()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, attackRange, mask);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                return collider.gameObject.transform;
            }
        }
        return null;
    }


    public override void Wond(BaseTank otherTank)
    {
        base.Wond(otherTank);
        if (healthBar !=null)
        {
            healthBar.GetComponent<monsterHealth>().updateHealhtBar(maxHp, currentHp);
            healthBar.transform.position = transform.position + new Vector3(0, 2, 0);
        }
        else
        {
            healthBar = Instantiate(Resources.Load<GameObject>("UI/helathback"), transform.position + new Vector3(0, 2, 0), Quaternion.identity);
            healthBar.transform.SetParent(healthCavas.transform);
            healthBar.GetComponent<monsterHealth>().updateHealhtBar(maxHp, currentHp);
        }
       


    }

    public override void Dead()
    {
        base.Dead();
        GameManager.Instance.getScore(score);//��ɱmonster���û���
        Destroy(healthBar);

    }


    public void OnDrawGizmos()
    {
        Gizmos.DrawSphere(maxRange.position, 1);
        Gizmos.DrawSphere(minRange.position, 1);
    }

    public void gameEnd()
    {
        //��Ϸ�����ķ���
        Debug.Log("��Ϸ����");
        this.tower.Rotate(Vector3.up, Time.deltaTime * 200);

    }
}
