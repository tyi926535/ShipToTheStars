using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddThings2 : MonoBehaviour
{
    public GameObject things;
    public int coficent;
    void Update()
    {
        if ((PlayerPrefs.HasKey("index") != false) && (PlayerPrefs.GetInt("index") > 0))
        {
            if (coficent < 0)
            {
                GameObject newGO = Instantiate(things, new Vector3(0, 0, 0), Quaternion.identity);
                newGO.transform.SetParent(this.transform);
                newGO.transform.localScale = new Vector3(1, 1, 1);
                newGO.SetActive(true);
                float posY = (-this.GetComponent<BoxCollider2D>().size.y / 2) + (things.GetComponent<BoxCollider2D>().size.y);
                newGO.transform.localPosition = new Vector3(0, posY, 0);
                coficent = Application.targetFrameRate ;
            }
            else { coficent--; }
        }
    }
}
