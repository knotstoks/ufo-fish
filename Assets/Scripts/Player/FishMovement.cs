using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float jumpForce;
    public float speed;
    public float jumpDuration;
    private float timer;
    private Rigidbody2D rb;
    private float horizontal;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {  
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (timer > 0) {
            timer -= Time.deltaTime;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

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
        
        if (Input.GetKey(KeyCode.Space) && timer <= 0)
        {
            timer = jumpDuration;
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}
