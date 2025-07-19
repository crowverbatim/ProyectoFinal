using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    bool IsGrounded;
    public LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        Collider2D col = GetComponent<Collider2D>();

        IsGrounded = Physics2D.OverlapCircle(transform.position - transform.up * ((col.bounds.extents.y / transform.localScale.y - col.offset.y) * transform.localScale.y), 0.01f, layerMask);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {


            rb.velocity = new Vector2(rb.velocity.x, speed);

        }

    }
}
