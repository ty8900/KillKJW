using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text1 : MonoBehaviour
{
    public Text Message;
    public string message;
    public int ctr;

    private string[] arr = { "Hi", "이것은 대화이다", "두번째 대화다", "대화 끝났다" };
    // Start is called before the first frame update
    void Start()
    {
        ctr = 0;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (ctr > 3)
            Destroy(gameObject);
        else
        message = arr[ctr];
        Message.text = message;
    }
}
