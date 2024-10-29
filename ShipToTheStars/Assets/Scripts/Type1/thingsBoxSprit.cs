using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class thingsBoxSprit : MonoBehaviour
{
    public Transform leftPlatform;
    public Transform rightPlatform;
    public int flag;

    // Start is called before the first frame update
    void Start()
    {
        var indexLeft = leftPlatform.position.x+163;
        var indexRight=rightPlatform.position.x-163;
        var index = Random.Range(indexLeft, indexRight);
        if (flag == 0)
        {
            var tBox = this.transform.Find("boxImg");
            tBox.position = new Vector3(index, tBox.position.y, tBox.position.z);
        }
        if (flag == 1)
        {
            this.transform.transform.position = new Vector3(index, this.transform.transform.position.y, this.transform.position.z);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("index") != false)
        {
            int index = PlayerPrefs.GetInt("index");
            if (index > 0)
            {
                transform.position += new Vector3(0, -12.5f - (index * 1), 0);
            }
        }
        if (flag == 1)
        {
            if (this.transform.localPosition.y < -650) { Debug.Log("flag=1"); Destroy(gameObject); }
        }

    }
    
}
