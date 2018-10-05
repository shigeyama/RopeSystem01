using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSystem : MonoBehaviour
{
    [SerializeField]
    bool isLine;

    [SerializeField]
    float speed;

    [SerializeField]
    GameObject[] bodys;

    Rigidbody2D rd2;

    LineRenderer lr;

    // Use this for initialization
    void Start()
    {
        rd2 = GetComponent<Rigidbody2D>();

        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // マウスのクリック
        if (Input.GetMouseButton(0))
        {
            Vector2 moveDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);

            moveDirection *= speed * Time.deltaTime;

            // 先頭の移動
            rd2.MovePosition((Vector2)transform.position + moveDirection);

            FollowingBody();
        }

        // LineRendrer表示用
        if (isLine)
        {
            RenderLine();
        }

        //-------------------------------------------------
        // ショートカット用

        if (Input.GetKeyDown(KeyCode.Z))
        {
            isLine = true;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            for(int i = 1; i < bodys.Length - 1; i++)
            {
                bodys[i].GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            bodys[bodys.Length - 1].transform.localScale = new Vector3(0.5f, 0.5f, 1);
            lr.endWidth = 0.5f;
        }

        //-------------------------------------------------
    }

    void RenderLine()
    {
        lr.positionCount = bodys.Length;

        for (int i = 0; i < bodys.Length; i++)
        {
            lr.SetPosition(i, bodys[i].transform.position);
        }
    }

    /// <summary>
    /// 追従用のプログラム
    /// </summary>
    void FollowingBody()
    {
        // 間隔
        float space = 1;

        for (int i = 1; i < bodys.Length; i++)
        {
            if (Vector2.Distance(bodys[i - 1].transform.position, bodys[i].transform.position) > space)
            {
                Vector2 bodyMoveVec = (bodys[i - 1].transform.position - bodys[i].transform.position);

                bodyMoveVec *= speed * Time.deltaTime;

                bodys[i].GetComponent<Rigidbody2D>().MovePosition((Vector2)bodys[i].transform.position + bodyMoveVec);
            }
        }
    }
}