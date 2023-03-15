using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    bool isGoal;
    [SerializeField] GameManager gm;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isGoal == false)
        {
            isGoal = true;
            gm.GameClear();
            //Debug.Log("Goal!!");
        }
    }
}
