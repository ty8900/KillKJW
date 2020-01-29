using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    // Start is called before the first frame update

    public float movespeed;
    public float moveforce;
    public GameObject body;
    public GameObject weapon;
    bool isGround;
    void Start()
    {
        isGround = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * movespeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * movespeed * Time.deltaTime);
        }


        if (Input.GetKeyDown(KeyCode.UpArrow) && isGround)
        {
            isGround = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * moveforce);
        }
    }
}
