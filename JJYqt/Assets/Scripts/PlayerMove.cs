using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove instance;
    public static GameObject Map;
    GameObject Wall;
    public float movespeed;
    public float moveforce;
    public float posx, posy, posz;
    public int HPcon; // HP control
    public Material damagedMaterial;
    public GameObject Weapon;
    public int Attackcon=0; // Attack control attack 도중 또 attack 불가

    private Transform site;
    private bool isJump,isGround,rot;//점프가능/땅에닿은 여부/왼쪽오른쪽 바라보는 방향
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Map = GameObject.Find(GameManager.instance.GetScene());
        Debug.Log(Map);
        site = transform;
        isGround = true;
        rot = false;
        HPcon = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Wall = Map.transform.Find("wall").gameObject;
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject == Wall)
            isGround = true;
        if (collision.gameObject.tag == "enemy" && HPcon == 1)
        {
            posx = transform.position.x;
            posy = transform.position.y;
            posz = transform.position.z;
            Stats.instance.minusHP();
            if (collision.gameObject.transform.position.x > posx) transform.position = new Vector3(posx - 150f, posy, posz);
            else transform.position = new Vector3(posx + 150f, posy, posz);
            StartCoroutine("whenDamaged");
        }
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
        if (Input.GetKeyDown(KeyCode.A) && Attackcon==0)
        {
            Debug.Log("oak");
            StartCoroutine("Attack");
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

    IEnumerator whenDamaged() 
    {
        float save = movespeed;
        movespeed = 0;
        HPcon = 0;
        SpriteRenderer rend = GetComponent<SpriteRenderer>();
        SpriteRenderer rend2 = Weapon.GetComponent<SpriteRenderer>();
        Material original = rend.material;
        for (int i = 10; i > 0; i--)
        {
            if (i % 2 == 0) { rend.material = damagedMaterial; rend2.material = damagedMaterial; }
            else { rend.material = original; rend2.material = original; }
            yield return new WaitForSeconds(0.05f);
        }
        movespeed = save;
        HPcon = 1;
    }

    IEnumerator Attack()
    {
        Attackcon = 1;
        float rox = Weapon.transform.eulerAngles.x;
        float roy = Weapon.transform.eulerAngles.y;
        float roz = Weapon.transform.eulerAngles.z;
        Quaternion q = Weapon.transform.rotation;
        for (int i = 10; i > 0; i--)
        {
            if (rot) roy = 0;
            else roy = 180;
            Debug.Log(i + " " + roz);
            if (i > 5) roz -= 10;
            else roz += 10;
            q = Quaternion.Euler(rox, roy, roz);
            Weapon.transform.rotation = q;
            yield return new WaitForSeconds(0.02f);
        }
        Attackcon = 0;
    }
}
