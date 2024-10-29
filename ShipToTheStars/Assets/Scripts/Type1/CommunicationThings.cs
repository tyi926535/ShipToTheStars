using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunicationThings : MonoBehaviour
{
    public GameObject GameOver;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int index = PlayerPrefs.GetInt("index");
        GameObject img;
        var image1 = collision.transform.Find("Image1");
        if (image1 != null)
        {
            if (image1.tag == "good")
            {
                index += 1;
                PlayerPrefs.SetInt("index", index);
            }
            if (image1.tag == "bad")
            {
                index = 1;
                PlayerPrefs.SetInt("index", index);
            }
            if (image1.tag == "kill")
            {
                index = 0;
                PlayerPrefs.SetInt("index", index);
                Destroy(this);
                GameOver.SetActive(true);
            }
        }

        Destroy(collision.transform.parent.gameObject);
    }

}
