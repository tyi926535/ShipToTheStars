using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestingInterfaces : MonoBehaviour
{
    private HingeJoint2D hj2d;
    public float speed;
    private Rigidbody2D r2d;
    public int flag;

    private void Start()
    {
        hj2d=this.GetComponent<HingeJoint2D>();
        r2d=this.GetComponent<Rigidbody2D>();
        /*
        JointMotor2D motor = hj2d.motor;
        motor.motorSpeed = 100f;
        hj2d.motor = motor;
        */
    }
    void Update()
    {
        float posX=this.transform.localPosition.x;
        float posY=this.transform.localPosition.y;
        
        this.transform.localPosition = new Vector2(posX, posY-speed);
    }

        private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "platform")
        {
            float platformW = collision.gameObject.GetComponent<BoxCollider2D>().size.x / 2;
            float platformH = collision.gameObject.GetComponent<BoxCollider2D>().size.y / 2;
            float platformX = collision.transform.localPosition.x;
            float platformY = collision.transform.localPosition.y;
            float posX2 = this.transform.localPosition.x;
            float posY2 = this.transform.localPosition.y;
            //Debug.Log("posY2="+ posY2+ "|platformY + platformH="+ "|posX2="+ posX2+ "|platformX - platformW="+ platformX - platformW);
            if ((posY2 > platformY + platformH) && (posX2 < platformX + platformW) && (posX2 > platformX - platformW))
            {
                
                r2d.bodyType= RigidbodyType2D.Dynamic;
                speed = 0;
                Debug.Log("platform");
                r2d.gravityScale = -10;
                
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
        }
    }
 }
