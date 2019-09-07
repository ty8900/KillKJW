using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public static Stats instance;
    private float HP;
    private float MP;



    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        HP = 8;
        MP = 8;
    }

    // Update is called once per frame
    public void minusHP()
    {
        HP--;
        GameObject diss;
        diss = GameObject.Find("HP" + HP);
        diss.SetActive(false);
    }
    void Update()
    {
        
    }
}
