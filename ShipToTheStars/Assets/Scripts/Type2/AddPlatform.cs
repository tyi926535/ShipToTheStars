using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlatform : MonoBehaviour
{
    public GameObject platform;
    void Start()
    {
        if ((PlayerPrefs.HasKey("index") != false) && (PlayerPrefs.GetInt("index") > 0))
        {
            var indicator1 = Random.Range(4, 8);
            for (int j = 0; j < indicator1; j++)
            {

                float hGroup = this.GetComponent<BoxCollider2D>().size.y;
                float hG2 = hGroup / 2, hGInd = hGroup / indicator1;
                float wGroup = this.GetComponent<BoxCollider2D>().size.x / 2;
                float posY = Random.Range(hG2 - (j * hGInd) - 20, hG2 - ((j + 1) * hGInd) + 20);
                float posX = Random.Range(-wGroup, wGroup);
                // for (int i = 0; i < indicator2; i++)
                //{
                GameObject newGO = Instantiate(platform, new Vector3(0, 0, 0), Quaternion.identity);
                newGO.transform.SetParent(this.transform);
                newGO.transform.localScale = new Vector3(1, 1, 1);
                newGO.SetActive(true);
                newGO.transform.localPosition = new Vector3(posX, posY, 0);
                //}
            }
        }
    }

}
