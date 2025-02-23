using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObject : MonoBehaviour
{
    public GameObject rotObject;
    public float rotateSpeed = 20f;

    // Update is called once per frame
    void Update()
    {
        rotObject.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }
}
