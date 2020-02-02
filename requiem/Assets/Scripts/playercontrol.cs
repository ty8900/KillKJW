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
    public Animator anime;
    bool isGround;
    bool attack;
    void Start()
    {
        isGround = true;
        attack = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isGround = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        attack = false; 
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.Translate(Vector3.right * movespeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.Translate(Vector3.left * movespeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGround)
        {
            isGround = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * moveforce);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            attack = true;
            anime.SetBool("attack", attack);
        }
        else anime.SetBool("attack", attack) ;
    }
}
