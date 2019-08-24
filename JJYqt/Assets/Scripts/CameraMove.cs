using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;

    private Vector3 temp;
    private float min1 = -6.6f; //왼쪽 배경 최댓값
    private float max1 = 5.4f;  //오른쪽 배경 최댓값

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(min1, -5.06f, -10f); // 초기 카메라 위치
        temp = transform.position;
    }

    // Update is called once per frame
    void Update()
    { 
         temp = transform.position;
         float dif = transform.position.x - player.transform.position.x;
         if(dif < -4.6f && transform.position.x != max1) //카메라와 플레이어 위치 간격이 -4.6보다 작으면 오른쪽으로 카메라 이동
         {
            temp.x += (-4.6f - dif);
         }
         if (dif > 6f)  // 카메라와 플레이어 위치 간격이 6보다 크면 왼쪽으로 카메라 이동 / 수치는 변경 가능 및 임의로 설정한 것 보기 좋은 각도로
        {
            temp.x -= (dif - 6f);
         }
            
         if (temp.x < min1)
         {
             temp.x = min1;
         }
         if (temp.x > max1)
         {
             temp.x = max1;
         }
    }

    private void FixedUpdate()
    {
        transform.position = temp;
    }
}
