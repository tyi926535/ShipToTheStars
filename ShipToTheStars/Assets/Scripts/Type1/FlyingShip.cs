using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class FlyingShip : MonoBehaviour
{
    public Transform pointStart;
    public Transform positLeft;
    public Transform positRight;
    public Sprite imgP;
    public Image imgP2;

    void Start()
    {
        PlayerPrefs.SetInt("index",1);
        
    }

    void Update()
    {
       if (this.transform.position.y!=pointStart.position.y)
        {
            if (Math.Abs(this.transform.position.y- pointStart.position.y) > 20.5f)
            {
                this.transform.position += new Vector3(0, 20.5f, 0);
                if(Math.Abs(this.transform.position.y - pointStart.position.y) < 300.5f)
                {imgP2.sprite = imgP; }
            }
            else
            {
                this.transform.position +=new Vector3(0, Math.Abs(this.transform.position.y - pointStart.position.y), 0);
            }
        }
       Touch touch = new Touch();
       if((touch.phase!= TouchPhase.Began)||(touch.phase == TouchPhase.Stationary))
        {
            var index = 45.5f;
            if (touch.position.x - this.transform.position.x > 0)
            {
                if (Math.Abs(this.transform.position.x - positRight.position.x) > index)
                {
                    this.transform.position += new Vector3(index, 0, 0);
                }
            }
            if (touch.position.x - this.transform.position.x < 0)
            {
                if (Math.Abs(this.transform.position.x - positLeft.position.x) > index)
                {
                    this.transform.position += new Vector3(-index, 0, 0);
                }
            }
        }
    
    }
}
