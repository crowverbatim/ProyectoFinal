using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    private Animator anim;

    private SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // Get input for A/D or left/right arrow keys

        if (horizontalInput != 0)
        {
            anim.SetBool("Run", true);
            if (horizontalInput > 0)
            {
                sp.flipX = false;
            }
            else if (horizontalInput < 0)
            {
                sp.flipX = true;
            }
        }
        else
        {
            anim.SetBool("Run", false);
        }
       


        
         rb.velocity= new Vector2(horizontalInput *speed , rb.velocity.y);
       
    }
}
