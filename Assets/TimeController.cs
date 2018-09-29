using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour {

    public Text TimeLabel;
    public float Time;
    public string TextTime;

    // Use this for initialization
    void Start () {

        TimeLabel.text = "Time : " + 0.00 + "Sec";


    }

    // Update is called once per frame
    void Update () {


        if (GlobalVariables.ResetTimeFlag == true)
        {
            Time = 0.000f;
            GlobalVariables.ResetTimeFlag = false;
        }

            Time = AddTime();
        TextTime = Time.ToString("f2");
        TimeLabel.text = "Time : " + TextTime + "Sec";

    }

    float AddTime()
    {
        return Time =  Time + 0.1f; 
    }
}
