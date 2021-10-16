using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float jumpForce;
    public float speed;
    public float jumpDuration;
    public float hitDuration;
    public AudioClip audioClip;
    private float timer;
    private float hitTimer;
    private bool hit = false;
    private Rigidbody2D rb;
    private float horizontal;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    void Start()
    {  
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // if (hit)
        // {
        //     hitTimer -= Time.deltaTime;
        //     if(hitTimer < 0)
        //     {
        //         hit = false;
        //     }
        // }
        if (timer > 0) {
            timer -= Time.deltaTime;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && timer <= 0 && !hit)
        {
            audioSource.PlayOneShot(audioClip);
            timer = jumpDuration;
            rb.velocity = Vector2.up * jumpForce;
        }

        Vector3 characterScale = transform.localScale;

        if (horizontal > 0) {
            characterScale.x = 1;
        } else {
            characterScale.x = -1;
        }

        if (horizontal != 0) {
            transform.localScale = characterScale;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed * Time.deltaTime, rb.velocity.y);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // if(collision.gameObject.tag == "Hazard")
        // {
        //     hit = true;
        //     hitTimer = hitDuration;
        // }
    }


}
