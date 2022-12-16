using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float jumpForce;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 4f;

    [Header("Components")]
    public Rigidbody2D Rb;
    public LayerMask groundLayer;

    [Header("Collision")]
    public bool onGround = false;
    public float groundLine = 4;



    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Ground Check
        bool onGroundOG = onGround;
        onGround = Physics2D.Raycast(transform.position, Vector2.down, groundLine, groundLayer);
        if (!onGroundOG && onGround)
        {
            Rb.velocity = new Vector2(Rb.velocity.x, 0);
        }

        // Input
        bool space = Input.GetKey(KeyCode.Space);
        bool rightKey = Input.GetKey(KeyCode.RightArrow);
        bool leftKey = Input.GetKey(KeyCode.LeftArrow);

        if (rightKey)
        {
            //Debug.Log("Right Key Pressed");
            Rb.AddForce(Vector2.right, ForceMode2D.Impulse);
        }

        if (leftKey)
        {
            //Debug.Log("Left Key Pressed");
            Rb.AddForce(Vector2.left, ForceMode2D.Impulse);
        }
        
        if (space && onGround)
        {
            Debug.Log("Space Key Pressed");
            Rb.velocity = new Vector2(Rb.velocity.x, 0);
            Rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        } else
        {
            //Debug.Log("space:" + space);
            //Debug.Log("onGround:" + onGround);
        }

        //Animation
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (onGround)
        {
            animator.SetBool("IsJumping", false);
        }
        else
        {
            animator.SetBool("IsJumping", true);
        }
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }
}
