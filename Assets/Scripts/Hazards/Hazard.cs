using UnityEngine;


public abstract class Hazard : MonoBehaviour {
    public float damage;
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            Vector2 playerPos = other.gameObject.transform.position;
            Vector2 pushForce = ((Vector2) transform.position - playerPos).normalized;

            other.gameObject.GetComponent<Rigidbody2D>().AddForce(pushForce);
        }
    }
}
