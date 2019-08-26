using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonMove : MonoBehaviour
{
    public GameObject player;

    private Vector3 temp;
    private float min1 = -6.6f; //왼쪽 배경 최댓값
    private float max1 = 5.4f;  //오른쪽 배경 최댓값
    float cam_x;
    float cam_y;
    float cam_z;
    private void Start()
    {

        cam_x = transform.position.x;
        cam_y = transform.position.y;
        cam_z = transform.position.z;

    }

    private void Update()
    {
        float pos_x = player.transform.position.x;
        float pos_y = player.transform.position.y;
        float pos_z = player.transform.position.z;
        transform.position = new Vector3(pos_x + 500, pos_y + 20, cam_z + pos_z);
    }
}
