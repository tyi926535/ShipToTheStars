using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FlyingShip2 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Transform ship;
    public Transform positLeft;
    public Transform positRight;
    public int indicator;
    public Sprite[] imgThings = new Sprite[3];

    void Start()
    {
        PlayerPrefs.SetInt("index", 1);
    }
    void Update()
    {
        if (indicator == 1)
        {
            var image1 = ship.transform.Find("Image");
            var index = 10.5f;
            float whithShip=ship.GetComponent<RectTransform>().rect.width;
            var touch0 = Input.GetTouch(0);
            if (touch0.position.x - ship.position.x > 0)
            {
                if (Math.Abs(ship.position.x - positRight.position.x) > (index+whithShip))
                {
                    ship.position += new Vector3(index, 0, 0);
                }
                if (image1 != null)
                {
                    image1.GetComponent<Image>().sprite = imgThings[1];

                }
            }
            if (touch0.position.x - ship.position.x < 0)
            {
                if (Math.Abs(ship.position.x - positLeft.position.x) > (index+whithShip))
                {
                    ship.position += new Vector3(-index, 0, 0);
                    if (image1 != null)
                    {
                        image1.GetComponent<Image>().sprite = imgThings[2];

                    }
                }
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        var image1 = ship.transform.Find("Image");
        indicator = 0;
        if (image1 != null)
        {
            image1.GetComponent<Image>().sprite = imgThings[0];
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        indicator = 1;
    }
}
