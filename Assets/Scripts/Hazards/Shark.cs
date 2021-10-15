using UnityEngine;

public class Shark : Hazard {
    [SerializeField] private Vector2 rightPos;
    [SerializeField] private Vector2 leftPos;
    [SerializeField] private bool goingRight;
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update() {
        if (goingRight && Mathf.Abs(transform.position.x - rightPos.x) < 0.5f) {
            // Change and move left
            goingRight = false;
        }

        if (!goingRight && Mathf.Abs(transform.position.x - leftPos.x) < 0.5f) {
            // Change and move right
            goingRight = true;
        }

        // Animation
        Vector3 characterScale = transform.localScale;

        if (goingRight) {
            characterScale.x = 4;
        } else {
            characterScale.x = -4;
        }

        if (rb.velocity.magnitude != 0) {
            transform.localScale = characterScale;
        }
    }
    private void FixedUpdate() {
        if (goingRight) {
            rb.AddForce(new Vector2(speed, 0));
        } else {
            rb.AddForce(new Vector2(-1 * speed, 0));
        }
    }
}