using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Text

public class Score : MonoBehaviour
{
    public Text CounterText;
    public Text HitText;

    static public int Counter;
    static public int Hit;
    void Start()
    {
        Counter = 0;
        Hit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CounterText.text = "명중 : " + Counter;
        HitText.text = "피격 : " + Hit;
    }
}
