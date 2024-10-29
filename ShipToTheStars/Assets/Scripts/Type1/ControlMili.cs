using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlMili : MonoBehaviour
{
    public Text control;
    public int indicator=0;
    void Update()
    {
        
        if ((PlayerPrefs.HasKey("index") != false)&&(indicator > (Application.targetFrameRate/2)))
        {
            int index = PlayerPrefs.GetInt("index");
            if (index > 0)
            {
                control.text = (Convert.ToInt32(control.text) + index).ToString();
            }
            indicator = 0;
        }
        indicator++;

    }
}
