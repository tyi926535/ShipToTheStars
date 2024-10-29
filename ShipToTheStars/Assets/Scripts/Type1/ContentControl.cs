using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ContentControl : MonoBehaviour
{
    public Text mili;
    float startPosition;
    void Start()
    {
        startPosition = this.transform.localPosition.y;

    }
    void Update()
    {
        var differencebig=512;
        var differencesmall = 512/128;
        int miliInt = int.Parse(mili.text);
        if((miliInt > 1 )&&(miliInt < 100))
        {
            if(this.transform.localPosition.y> (startPosition - differencebig*1))
            {
                this.transform.localPosition -= new Vector3(0, differencesmall, 0);
            }
        }
        if((miliInt > 1200 )&& (miliInt < 1500))
        {
            if (this.transform.localPosition.y > (startPosition - differencebig * 4))
            {
                this.transform.localPosition -= new Vector3(0, differencesmall, 0);
            }
        }
    }
}
