using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCamera : MonoBehaviour
{
    public int coficent;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = coficent;
    }

    
}
