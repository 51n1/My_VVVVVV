using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public enum DIRECTION_TYPE
    {
        STOP,
        RIGHT,
        LEFT
    }
    DIRECTION_TYPE direction = DIRECTION_TYPE.STOP;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator anim;
    AudioSource audioSource;

    [SerializeField] float speed = 3;
    [SerializeField] GameManager gm;

    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip trapSound;

    bool isGround;
    bool isDead;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        if (isDead == false)
        {
            if (x == 0)
            {
                direction = DIRECTION_TYPE.STOP;
            }
            else if (x > 0)
            {
                direction = DIRECTION_TYPE.RIGHT;
            }
            else if (x < 0)
            {
                direction = DIRECTION_TYPE.LEFT;
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGround)
            {
                Jump();
            }
        }
    }

    void FixedUpdate()
    {
        float x_speed = 0;
        switch (direction)
        {
            case DIRECTION_TYPE.STOP:
                x_speed = 0;
                break;
            case DIRECTION_TYPE.RIGHT:
                x_speed = speed;
                transform.localScale = new Vector3(1, transform.localScale.y, 1);
                break;
            case DIRECTION_TYPE.LEFT:
                x_speed = -speed;
                transform.localScale = new Vector3(-1, transform.localScale.y, 1);
                break;
        }

        rb.velocity = new Vector2(x_speed, rb.velocity.y);

    }

    void Jump()
    {
        rb.velocity = Vector2.zero;

        transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, 1);

        rb.gravityScale = -rb.gravityScale;

        audioSource.PlayOneShot(jumpSound);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }

        if (collision.gameObject.tag == "Trap")
        {
            isDead = true;
            audioSource.PlayOneShot(trapSound);
            StartCoroutine(GameOver());
            //Debug.Log("Trap!!");
        }

        if (collision.gameObject.tag == "BounceBar")
        {
            Jump();
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BounceBar")
        {
            Jump();
        }
    }

    IEnumerator GameOver()
    {
        anim.SetTrigger("Dead");

        direction = DIRECTION_TYPE.STOP;
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;

        int count = 0;
        while(count < 10)
        {
            spriteRenderer.color = new Color32(255, 0, 0, 100);
            yield return new WaitForSeconds(0.05f);

            spriteRenderer.color = new Color32(255, 0, 0, 255);
            yield return new WaitForSeconds(0.05f);

            count++;
        }

        gm.GameOver();
    }


}
