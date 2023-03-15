using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] bool isCameraHorizontal;

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isCameraHorizontal)
            {
                if (collision.transform.position.y < transform.position.y)
                {
                    // Down
                    cam.transform.position += new Vector3(0f, -10f, 0f);
                }
                else
                {
                    // Up
                    cam.transform.position += new Vector3(0f, 10f, 0f);
                }
            } else
            {
                if (collision.transform.position.x < transform.position.x)
                {
                    // Left
                    cam.transform.position += new Vector3(-18f, 0f, 0f);
                }
                else
                {
                    // Right
                    cam.transform.position += new Vector3(18f, 0f, 0f);
                }
            }
        }
    }
}
