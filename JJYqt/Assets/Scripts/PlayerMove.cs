using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float movespeed;
    public float moveforce;

    private Transform site;
    private bool isJump,isGround;
    private float t;
    // Start is called before the first frame update
    void Start()
    {
        site = transform;
        isGround = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == GameObject.Find("wall"))
            isGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            site.Translate(Vector3.left * movespeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            site.Translate(Vector3.right * movespeed * Time.deltaTime, Space.World);
        }
        if (Input.GetButtonDown("Jump") && isGround)
        {
            isJump = true;
            isGround = false;
        }
    }
    void FixedUpdate()
    {
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
