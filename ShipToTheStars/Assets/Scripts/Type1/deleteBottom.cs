using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteBottom : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.transform.parent.gameObject);
    }

}
