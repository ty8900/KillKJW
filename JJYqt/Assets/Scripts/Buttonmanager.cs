using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttonmanager: MonoBehaviour
{
    public Button QuestButton;
    public text1 t1;
    // Start is called before the first frame update
    void Start()
    {
        QuestButton.onClick.AddListener(go);
    }

    // Update is called once per frame
    void go()
    {
        t1.ctr++;
    }
    void Update()
    {
        
    }
}
