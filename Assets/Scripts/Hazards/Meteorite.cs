using System.Collections;
using UnityEngine;

public class Meteorite : Hazard {
    [HideInInspector] public Vector2 movingTo;
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private IEnumerator Start() {
        rb = GetComponent<Rigidbody2D>();
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
    private void FixedUpdate() {
        transform.Rotate (0, 0, 200 * Time.deltaTime);

        rb.AddForce(movingTo * speed);
    }
}
