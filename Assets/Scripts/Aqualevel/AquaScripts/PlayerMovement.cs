using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float dirx;
    public bool isGrounded;
    bool jumpButtonPressed;
    public float jump_height = 5f;
    public int extrajumps = 1;

    private bool canDash = true;
    private bool isDashing;
    public float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 0.5f;

    private bool isFacingRight = true;

    [SerializeField] private TrailRenderer tr;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
       
        dirx = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpButtonPressed = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpButtonPressed = false;
        }
        if (isGrounded == true)
        {
            extrajumps = 1;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true && extrajumps > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump_height);
            extrajumps--;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == false && extrajumps > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump_height);
            extrajumps--;
        }

        if ((isGrounded == true) && jumpButtonPressed == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
        Flip();

    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        rb.velocity = new Vector2(dirx * 5, rb.velocity.y);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            Destroy(gameObject);
        SceneManager.LoadScene(2);
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    private void Flip()
    {
        if (isFacingRight && dirx < 0f || !isFacingRight && dirx > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }    

}
