using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StaticContentStart : MonoBehaviour
{
    public Text type1Text;
    public Text type2Text;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("goodResult1") != false)
        {
            type1Text.text = PlayerPrefs.GetInt("goodResult1").ToString();
        }
        else
        {
            PlayerPrefs.SetInt("goodResult1", 0);
        }
        if (PlayerPrefs.HasKey("goodResult2") != false)
        {
            type2Text.text = PlayerPrefs.GetInt("goodResult2").ToString();
        }
        else
        {
            PlayerPrefs.SetInt("goodResult2", 0);
        }
    }
}
