using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // Get input for A/D or left/right arrow keys
        float verticalInput = Input.GetAxisRaw("Vertical");   // Get input for W/S or up/down arrow keys

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        rb.velocity = movement * speed;
    }
}
