using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBar : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    [SerializeField] Color32 blinkColor;
    Color defaultColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Blink());
        }
    }

    IEnumerator Blink()
    {
        int count = 0;
        while (count < 10)
        {
            spriteRenderer.color = new Color32(blinkColor.r, blinkColor.g, blinkColor.b, 100);
            yield return new WaitForSeconds(0.05f);

            spriteRenderer.color = new Color32(blinkColor.r, blinkColor.g, blinkColor.b, 255);
            yield return new WaitForSeconds(0.05f);

            count++;
        }
        spriteRenderer.color = defaultColor;
    }
}
