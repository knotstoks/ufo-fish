using UnityEngine;

public class Satellite : Hazard {
    [SerializeField] private Vector2 center;
    [SerializeField] private float speed;
    [SerializeField] private bool isClockwise;
    private Rigidbody2D rb;
    private float time;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();

        if (!isClockwise) {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }
    private void FixedUpdate() {
        transform.RotateAround(center, Vector3.forward, speed * Time.deltaTime);
    }
}
