using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    public float movespeed;
    float pos_x;
    float pos_y;
    void Awake()
    {
        player = GameObject.Find("player");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos_x = player.transform.position.x;
        pos_y = player.transform.position.y;
        //Debug.Log(pos_x + " " + transform.position.x);
        if (PlayerMove.instance.HPcon == 1)
        {
            if (pos_x > transform.position.x) transform.Translate(Vector3.right * movespeed * Time.deltaTime, Space.World);
            else transform.Translate(Vector3.left * movespeed * Time.deltaTime, Space.World);
        }
    }
}
