using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Rocket : Hazard 
{ 
    [SerializeField] private float speed;
    private Rigidbody2D rb;

    private IEnumerator Start()
    {
        rb = GetComponent<Rigidbody2D>();

        yield return new WaitForSeconds(5);

        Destroy(gameObject);
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(0, speed));
    }
}
