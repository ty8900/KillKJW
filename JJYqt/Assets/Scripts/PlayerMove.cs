using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float movespeed;
    public float moveforce;

    private Transform site;
    private bool isJump,isGround,rot;//점프가능/땅에닿은 여부/왼쪽오른쪽 바라보는 방향
    // Start is called before the first frame update
    void Start()
    {
        site = transform;
        isGround = true;
        rot = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == GameObject.Find("wall"))
            isGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            site.Translate(Vector3.left * movespeed * Time.deltaTime, Space.World);
            rot = false;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            site.Translate(Vector3.right * movespeed * Time.deltaTime, Space.World);
            rot = true;
        }
        if (Input.GetButtonDown("Jump") && isGround)
        {
            isJump = true;
            isGround = false;
        }
    }
    void FixedUpdate()
    {
        if(rot)
        transform.rotation = Quaternion.Euler(0, 0, 0);
        else
        transform.rotation = Quaternion.Euler(0, 180, 0);
        Jump();
    }

    void Jump()
    {
        if (isJump)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * moveforce);
            isJump = false;
        }
    }
}
