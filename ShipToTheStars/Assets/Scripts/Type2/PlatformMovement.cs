using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private int stop;
    public float speed;
    private float acceleration;

    // Update is called once per frame
    private void Start()
    {
        float wGPlatform = this.transform.parent.GetComponent<BoxCollider2D>().size.x / 2;
        float PosX = this.transform.localPosition.x;
        if (PosX > 0) { speed *= -1; }
        stop = 0;
        acceleration = Random.Range(1.0f, 3.0f);
        speed *= acceleration;
    }
    void Update()
    {
        if ((PlayerPrefs.HasKey("index") != false) && (PlayerPrefs.GetInt("index") > 0))
        {
            if (stop < 0)
            {
                float wGPlatform = this.transform.parent.GetComponent<BoxCollider2D>().size.x / 2;
                float PosX = this.transform.localPosition.x;
                if ((PosX < -wGPlatform) || (PosX > wGPlatform)) { speed *= -1; }
                this.transform.localPosition = new Vector3(this.transform.localPosition.x + speed, this.transform.localPosition.y, 0);
                stop = 2;

            }
            else { stop--; }
        }
    }
}
