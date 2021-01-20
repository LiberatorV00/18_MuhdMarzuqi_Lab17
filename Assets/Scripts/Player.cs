using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movespeed;
    public float jumpforce;

    public int healthCount;
    public int coinCount;

    private Rigidbody2D rb;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float hVelocity = 0;
        float vVelocity = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            hVelocity = -movespeed;
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetFloat("xVelocity", Mathf.Abs(hVelocity));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            hVelocity = movespeed;
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetFloat("xVelocity", Mathf.Abs(hVelocity));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            vVelocity = jumpforce;
            animator.SetTrigger("JumpTrigger");
        }


        hVelocity = Mathf.Clamp(rb.velocity.x + hVelocity, -5, 5);

        rb.velocity = new Vector2(hVelocity, rb.velocity.y + vVelocity);

        animator.SetFloat("xVelocity", Mathf.Abs(hVelocity));

        animator.SetFloat("xVelocity", 0);

        animator.SetTrigger("JumpTrigger");
    }
}
