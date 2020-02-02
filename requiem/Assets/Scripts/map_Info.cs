using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_Info : MonoBehaviour
{
    // Start is called before the first frame update
    public map_Info instance;

    
    int total_monster;
    int field_monster;

    map_Control.Scene current;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        total_monster = 0;
        field_monster = 0;

    }

    // Update is called once per frame
    void Update()
    {
        current = map_Control.instance.GetScene();
        if (current==map_Control.Scene.Alley)
        {
            total_monster = 10;
            field_monster = 5;
        }
    }
}
