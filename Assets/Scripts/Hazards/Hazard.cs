using UnityEngine;


public abstract class Hazard : MonoBehaviour {
    public float damage;
    public float force;
  
    private void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            Vector2 playerPos = other.gameObject.transform.position;
            float x = playerPos.x - transform.position.x;
            float y = Mathf.Abs(playerPos.y - transform.position.y);
            Vector2 pushForce = new Vector2(x, -1 * y).normalized;
          
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(pushForce * force);
        }
    }

        private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            Vector2 playerPos = other.gameObject.transform.position;
            float x = playerPos.x - transform.position.x;
            float y = Mathf.Abs(playerPos.y - transform.position.y);
            Vector2 pushForce = new Vector2(x, -1 * y).normalized;
          
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(pushForce * force);
        }
    }
}
