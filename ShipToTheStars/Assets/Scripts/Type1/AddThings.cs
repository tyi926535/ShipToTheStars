using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AddThings : MonoBehaviour
{
    public GameObject[] boxImg=new GameObject[7];
    public int coficent;
    public int coficentPlus;
    public Transform pointThing;
    public Text mili;

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("index") != false)
        {
            var indicator = Random.Range(0, boxImg.Length - 1);
            int index = PlayerPrefs.GetInt("index");
            if ((coficent < 0)&&(index>0))
            {
                if ((coficentPlus > 90))
                {
                    int miliInt = int.Parse(mili.text);
                    if ((miliInt > 1200)) { goto gap; }
                }
                if ((coficentPlus > 0) && (coficentPlus < 90))
                {
                    int miliInt = int.Parse(mili.text);
                    if (miliInt < 1300) { goto gap; }
                }
                GameObject newGO = Instantiate(boxImg[indicator], new Vector3(pointThing.position.x, pointThing.position.y, 0), Quaternion.identity);
                newGO.transform.SetParent(this.transform);
                newGO.transform.localScale = new Vector3(1, 1, 1);
                if(coficentPlus == 0)
                {
                    var newGO2 = newGO.transform.Find("boxImg");
                    var image1 = newGO2.transform.Find("Image1");
                    image1.gameObject.SetActive(true);
                }
                newGO.SetActive(true);
                newGO.gameObject.SetActive(true);
            gap:
                coficent = Application.targetFrameRate * index+ coficentPlus;

            }
            else
            {
                coficent -= index;
            }
        }
    }
}
