using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Airplane : Hazard {
    [HideInInspector] public bool goingRight;
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private IEnumerator Start() {
        rb = GetComponent<Rigidbody2D>();

        if (goingRight) {
            Vector3 characterScale = transform.localScale;
            characterScale.x = -7;
            transform.localScale = characterScale;
        }

        yield return new WaitForSeconds(5);

        Destroy(gameObject);
    }
    private void FixedUpdate() {
        if (goingRight) {
            rb.AddForce(new Vector2(speed, 0));
        } else {
            rb.AddForce(new Vector2(-1 * speed, 0));
        }
    }
}
