using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FishMovement : MonoBehaviour
{
    public float jumpForce;
    public float speed;
    private float timer;
    public float jumpDuration;
    private Rigidbody2D rb;
    private float horizontal;

    // Start is called before the first frame update
    void Start()
    {
       
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0) {
            timer -= Time.deltaTime;
        }
        horizontal = Input.GetAxisRaw("Horizontal");

    }

    void FixedUpdate()
    {
       
        rb.velocity = new Vector2(horizontal * speed * Time.deltaTime, rb.velocity.y);
        
        if (Input.GetKey(KeyCode.Space) && timer <= 0)
        {
            timer = jumpDuration;
            rb.velocity = Vector2.up * jumpForce;
        }

        

    }
}
