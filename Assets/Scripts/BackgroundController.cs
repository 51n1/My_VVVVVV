using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField]
    float scrollSpeed = 0.1f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(-scrollSpeed, 0f, 0f);

        if (transform.localPosition.x < -20f)
        {
            transform.localPosition = new Vector3(20f, 0f, 10f);
        }
    }
}
