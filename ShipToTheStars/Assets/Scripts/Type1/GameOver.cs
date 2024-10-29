using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text goodResult;
    public Text nowResult;
    public Text mili;
    public int flag;
    void Start()
    {
        int nRInt=int.Parse(mili.text);
        int gRInt=0;
        if (flag == 1)
        {
            if (PlayerPrefs.HasKey("goodResult1") != false)
            {
                gRInt = PlayerPrefs.GetInt("goodResult1");
                if (nRInt > gRInt) { gRInt = nRInt; }
                PlayerPrefs.SetInt("goodResult1", gRInt);
            }
            else { PlayerPrefs.SetInt("goodResult1", nRInt); gRInt = nRInt; }
        }
        if (flag == 2)
        {
            if (PlayerPrefs.HasKey("goodResult2") != false)
            {
                gRInt = PlayerPrefs.GetInt("goodResult2");
                if (nRInt > gRInt) { gRInt = nRInt; }
                PlayerPrefs.SetInt("goodResult2", gRInt);
            }
            else { PlayerPrefs.SetInt("goodResult2", nRInt); gRInt = nRInt; }
        }

        nowResult.text = nRInt.ToString();
        goodResult.text = gRInt.ToString();
    }
}
