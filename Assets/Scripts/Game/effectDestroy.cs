using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectDestroy : MonoBehaviour
{

    public float delayTime;
    private float timer;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delayTime)
        {
            Destroy(gameObject);
        }
    }
}
