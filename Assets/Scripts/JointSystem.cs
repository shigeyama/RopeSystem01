using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointSystem : MonoBehaviour
{
    [SerializeField]
    bool isLine = false;

    [SerializeField]
    GameObject[] bodys;

    LineRenderer lr;

    // Use this for initialization
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isLine)
        {
            RenderLine();
        }
    }

    void RenderLine()
    {
        lr.positionCount = bodys.Length;

        for (int i = 0; i < bodys.Length; i++)
        {
            lr.SetPosition(i, bodys[i].transform.position);
        }
    }
}
