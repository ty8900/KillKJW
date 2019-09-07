using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static GameObject Map;
    GameObject Wall;
    public float movespeed;
    public float moveforce;
    public float posx, posy, posz;
    public int HPcon;
    Color damageColor;
    public Material damagedMaterial;
    

    private Transform site;
    private bool isJump,isGround,rot;//점프가능/땅에닿은 여부/왼쪽오른쪽 바라보는 방향
    // Start is called before the first frame update
    void Start()
    {
        Map = GameObject.Find(GameManager.instance.GetScene());
        Debug.Log(Map);
        site = transform;
        isGround = true;
        rot = false;
        HPcon = 1;
        damageColor = new Color(111f, 111f, 111f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Wall = Map.transform.Find("wall").gameObject;
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject == Wall)
            isGround = true;
        if(collision.gameObject.tag == "enemy" && HPcon==1 )
        {
            posx = transform.position.x;
            posy = transform.position.y;
            posz = transform.position.z;
            Stats.instance.minusHP();
            transform.position = new Vector3(posx-150f, posy, posz);
            StartCoroutine("waitPlayer");
        }
    }
    IEnumerator waitPlayer()
    {
        float save = movespeed;
        movespeed = 0;
        HPcon = 0;
        SpriteRenderer rend = GetComponent<SpriteRenderer>();
        Material original = rend.material;
        for(int i=10; i>0; i--)
        {
            if (i % 2 == 0) rend.material = damagedMaterial;
            else rend.material = original;
            yield return new WaitForSeconds(0.05f);
        }
        movespeed = save;
        HPcon = 1;
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
