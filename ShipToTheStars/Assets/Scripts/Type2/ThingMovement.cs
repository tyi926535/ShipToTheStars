using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;
using static Unity.VisualScripting.Member;

public class ThingMovement : MonoBehaviour
{
    public GameObject gThings;
    public int coficent1, coficent2;
    private int  state=0;
    private float a, b, speed, c;
    private HingeJoint2D hj2d;
    private Rigidbody2D r2d;
    //private float posXPlus;
    bool direction=true;

    void Start()
    {
        hj2d = this.GetComponent<HingeJoint2D>();
        r2d = this.GetComponent<Rigidbody2D>();
        speed = UnityEngine.Random.Range(0.7f, 2f);
        a = UnityEngine.Random.Range(4, 15);
        b = UnityEngine.Random.Range(0, -this.transform.localPosition.y);
        int x =     UnityEngine.Random.Range(-2, 2);
        if (x > 0) { x = 1; } else { x = -1; }

        float posX = Mathf.Sqrt(((this.transform.localPosition.y - b) * (-a))) *x;
        if (posX < 0) { direction = true; } else { direction = false; speed *= -1; }
        
        float wGT=gThings.GetComponent<BoxCollider2D>().size.x/2;
        float wThings = this.GetComponent<BoxCollider2D>().size.x;
        //float posX=Random.Range(-wGT+wThings+30,wGT-wThings-30);
        //posXPlus= Random.Range(100, 100);
        this.transform.localPosition = new Vector2(posX, this.transform.localPosition.y);

    }

    void Update()
    {
        if ((PlayerPrefs.HasKey("index") != false) && (PlayerPrefs.GetInt("index") > 0))
        {
            if (coficent1 == 0)
            {
                coficent1 = coficent2;
                float posX = this.transform.localPosition.x + speed;
                float posY = 0;
                if (state == 0)
                {
                    posY = (-posX * posX) / a + b;
                    this.transform.localPosition = new Vector2(posX, posY);
                }
                else {  }
            }
            coficent1--;


            float wGT = gThings.GetComponent<BoxCollider2D>().size.x / 2;
            float hGT = gThings.GetComponent<BoxCollider2D>().size.y / 2;
            var posThing = this.transform.localPosition;
            if ((posThing.x < -wGT) || (posThing.y < -hGT) || (posThing.x > wGT) || (posThing.y > hGT)) { Destroy(this.gameObject); }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name== "platform(Clone)") 
        {
            float platformW = collision.gameObject.GetComponent<BoxCollider2D>().size.x / 2;
            float platformH = collision.gameObject.GetComponent<BoxCollider2D>().size.y / 2;
            float platformX = collision.transform.localPosition.x;
            float platformY = collision.transform.localPosition.y;
            float posX2 = this.transform.localPosition.x;
            float posY2 = this.transform.localPosition.y;
            if((posY2> platformY + platformH) && (posX2< platformX+ platformW)&&(posX2 > platformX - platformW)) 
            {
                state = 1;
                r2d.bodyType = RigidbodyType2D.Dynamic;
                speed = 0;
                Debug.Log("platform");
                r2d.gravityScale = -50;
                int flag = 1;
                if (direction ==false) { flag = 2; }
                if (flag == 1)
                {
                    hj2d.anchor = new Vector2(50, -25);
                    hj2d.breakTorque = Mathf.Infinity;
                    hj2d.useMotor = true;
                }
                if (flag == 2)
                {
                    hj2d.anchor = new Vector2(-50, -25);
                    hj2d.breakTorque = 400;
                    hj2d.useMotor = false;
                }

            }
            /*
            float posX2= this.transform.localPosition.x;
            float posY2= this.transform.localPosition.y;
            float posX1= this.transform.localPosition.x-speed;
            float posY1 = 0;
            if (state==0) { posY1= (-posX1 * posX1) / a + b; } else { posY1 = b * posX1 / a + c; }
            float a1=posX2 - posX1;
            float b1=posY2 - posY1;
            a = -b1;b = a1; c = posY2;
            state = 1;
            float platformW = collision.gameObject.GetComponent<BoxCollider2D>().size.x/2;
            float platformH= collision.gameObject.GetComponent<BoxCollider2D>().size.y/2;
            float platformX = collision.transform.localPosition.x;
            float platformY = collision.transform.localPosition.y;
            if (this.transform.localPosition.x> platformX+ platformW) { speed *= -1; c = (posY2 - posY1) * (-1) + posY2; }//Справа
            if (this.transform.localPosition.x < platformX - platformW) {  speed *= -1; c = (posY2 - posY1) * (-1) + posY2; }//Слева
            speed *= 2;
            */
        }
        //print(collision.gameObject.name);
    }

}
