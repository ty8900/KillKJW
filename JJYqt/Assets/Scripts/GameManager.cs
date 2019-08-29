using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    [SerializeField]
    GameObject Map;

    public enum Scene
    {
        Alley, School, Roof, Cafeteria, Classroom
    }

    public Scene currentScene;


    void Awake()
    {
        instance = this;
        currentScene = Scene.Alley;
    }
    void Start()
    {
        
    }
    public string GetScene()
    {
        switch(currentScene)
        {
            case Scene.Alley: return "Alley";
            case Scene.Cafeteria: return "Cafeteria";
            case Scene.Classroom: return "Classroom";
            case Scene.Roof: return "Roof";
            case Scene.School: return "School";
        }
        return "";
            
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
