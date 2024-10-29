using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MassiveImg : MonoBehaviour
{
    public Sprite[] imgThings = new Sprite[9];
    public int[] ints = new int[9];

    void Start()
    {
       var index=Random.Range(0,imgThings.Length);
       this.GetComponent<Image>().sprite = imgThings[index];
        if (ints[index] == 0) { this.tag = "kill";}
        if (ints[index] == 1) { this.tag = "good"; }
        if (ints[index] == -1) { this.tag = "bad"; }

    }
}
