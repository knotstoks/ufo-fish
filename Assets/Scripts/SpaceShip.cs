using UnityEngine;

public class SpaceShip : Hazard
{
    public Transform center;
    public float speed;
    public bool clockwise;
    public Vector2 offset;
    private Rigidbody2D rb;
    private float radius;
    private float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        radius = Vector2.Distance(center.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (clockwise)
        {
            time -= Time.deltaTime * speed;
        } else
        {
            time += Time.deltaTime * speed;
        }
        
    }

    private void FixedUpdate()
    {
        rb.MovePosition((Vector2) center.position + new Vector2(radius*Mathf.Cos(time), radius * Mathf.Sin(time)) + offset);
       
    }
}
