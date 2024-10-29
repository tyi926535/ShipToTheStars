using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class ControlPanel : MonoBehaviour,IDragHandler,IPointerUpHandler, IPointerDownHandler
{
    public LineRenderer lineDraw;
    public GameObject lineImg;
    public GameObject lineImgL;
    public int index;
    public GameObject[] Img;
    public GameObject[] ImgL;
    public GameObject groupLine;
    public GameObject ImgThingth;
    public Text counter;
    public GameObject PanelGameOver;
    private void Start()
    {
        lineDraw.startWidth = 0.005f;
        lineDraw.endWidth = 0.01f;
        lineDraw.positionCount = 0;
        PlayerPrefs.SetInt("index", 1);

        // if (Img[0] != null) { Destroy(Img[0]); }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       lineDraw.positionCount = 0;
       index = 0;
       for (int i = 0; i < Img.Length; i++) { if (Img[i] != null) { Destroy(Img[i].gameObject); } }
       for (int i = 0; i < ImgL.Length; i++) { if (ImgL[i] != null) { Destroy(ImgL[i].gameObject); } }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        index = 0;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if ((PlayerPrefs.HasKey("index") != false) && (PlayerPrefs.GetInt("index") > 0))
        {
            GameObject GOC5 = eventData.pointerEnter;
           if (GOC5.name == ImgThingth.name) { DeleteThingth(GOC5); }
            Vector3 currentPoint = eventData.position;
            lineDraw.positionCount++;
            lineDraw.SetPosition(lineDraw.positionCount - 1, currentPoint);
            if (index < Img.Length - 1)
            {
                var newGO = CreatElement(currentPoint);
                Img[index] = newGO;
                if (index > 0)
                {
                    var newGOL = CreatElementL(Img[index - 1].transform.localPosition, Img[index].transform.localPosition, currentPoint);
                    ImgL[index - 1] = newGOL;
                }
                index++;
            }
            else
            {
                Destroy(Img[0].gameObject);
                if (ImgL[0] != null) { Destroy(ImgL[0].gameObject); }

                var tmp = new List<GameObject>(Img);
                tmp.RemoveAt(0);
                var newGO = CreatElement(currentPoint);
                tmp.Add(newGO);
                Img = tmp.ToArray();

                var tmpL = new List<GameObject>(ImgL);
                tmpL.RemoveAt(0);
                if ((Img[index] != null) && (Img[index - 1] != null))
                {
                    var newGOL = CreatElementL(Img[index - 1].transform.localPosition, Img[index].transform.localPosition, currentPoint);
                    tmpL.Add(newGOL);
                }
                while (tmpL.Count < Img.Length)
                {
                    tmpL.Add(null);
                }
                ImgL = tmpL.ToArray();
            }
        }
    }

    private GameObject CreatElement(Vector3 currentPoint)
    {
        GameObject newGO = Instantiate(lineImg, new Vector3(0, 0, 0), Quaternion.identity);
        newGO.transform.SetParent(groupLine.transform);
        newGO.transform.localScale = new Vector3(1, 1, 1);
        newGO.SetActive(true);
        newGO.transform.position = currentPoint;
        return newGO;
    }


    private GameObject CreatElementL(Vector3 point2, Vector3 point1, Vector3 currentPoint)
    {
        float x1 = point1.x;
        float y1 = point1.y;
        float x2 = point2.x;
        float y2 = point2.y;
        double lengthLine = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        GameObject newGO = Instantiate(lineImgL, new Vector3(0, 0, 0), Quaternion.identity);

        newGO.GetComponent<RectTransform>().sizeDelta=new Vector2(7,(float)lengthLine) ;

        newGO.transform.SetParent(groupLine.transform);
        newGO.transform.localScale = new Vector3(1, 1, 1);
        newGO.SetActive(true);
        newGO.transform.position = currentPoint;
        
        float posX = (point1.x - point2.x)/2+ point2.x; float posY=(point1.y - point2.y)/2+ point2.y;
        if (point2.x > point1.x) { posX= (point2.x - point1.x)/2+ point1.x; }
        if (point2.y > point1.y) { posY = (point2.y - point1.y)/2+ point1.y; }
        newGO.transform.localPosition= new Vector3(posX, posY, point1.z);
        float differenceY = Math.Abs(y1 - y2);
        double Corner = 0; 
        Corner = Math.Acos(differenceY / lengthLine) * 180 / Math.PI; //”гол

            if ((y1 > y2) && (x1 > x2)) { Corner *= -1; }
        else
        {
            if ((y2 > y1) && (x2 > x1)) { Corner *= -1; }
        }

        if (Double.IsNaN((float)Corner)==false) { newGO.transform.rotation = Quaternion.Euler(new Vector3(0, 0, (float)Corner)); }
        return newGO;
    }

    private void DeleteThingth(GameObject thingthGO)
    {
        string tagthingth = thingthGO.tag;
        if(tagthingth == "good")
        {
            int counterInt = int.Parse(counter.text);
            counter.text = (counterInt+10).ToString();
        }
        if(tagthingth == "bad")
        {
            int counterInt = int.Parse(counter.text);
            if(counterInt > 10) { counter.text = (counterInt - 10).ToString(); }
            else { counter.text = "0"; }
        }
        if (tagthingth == "kill")
        { 
            PanelGameOver.SetActive(true);
            if (PlayerPrefs.HasKey("index") != false) {
                PlayerPrefs.SetInt("index", 0);
            }
        }
        Destroy(thingthGO.transform.parent.gameObject);
    }

    
}
