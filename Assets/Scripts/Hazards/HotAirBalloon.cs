using UnityEngine;

public class HotAirBalloon : Hazard
{
    [SerializeField] private Vector2 upPos;
    [SerializeField] private Vector2 downPos;
    [SerializeField] private bool goingUp;
    [SerializeField] private float speed;

    private Rigidbody2D rb;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    private void Update()
    {
        if (goingUp && Mathf.Abs(transform.position.y - upPos.y) < 0.5f)
        {
            // Change and move down
            goingUp = false;
        }

        if (!goingUp && Mathf.Abs(transform.position.y - downPos.y) < 0.5f)
        {
            // Change and move up
            goingUp = true;
        }

    }
    private void FixedUpdate()
    {
        if (goingUp)
        {
            rb.AddForce(new Vector2(0, speed));
        }
        else
        {
            rb.AddForce(new Vector2(0, -1*speed));
        }
    }
}
