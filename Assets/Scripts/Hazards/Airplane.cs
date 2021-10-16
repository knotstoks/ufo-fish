using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Airplane : Hazard {
    [HideInInspector] public bool goingRight;
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();

        if (goingRight) {
            Vector3 characterScale = transform.localScale;
            characterScale.x = -7;
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
