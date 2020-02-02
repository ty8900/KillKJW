using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_Control : MonoBehaviour
{
    // Start is called before the first frame update
    public static map_Control instance;
    public enum Scene
    {
        Alley, School, Roof, Cafeteria, Classroom
    }

    Scene currentScene;
    int current_monster;
    int current_field_monster;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        current_field_monster = 0;
        current_monster = 0;
        currentScene = Scene.Alley;
    }

    public Scene GetScene()
    {
        return currentScene;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
