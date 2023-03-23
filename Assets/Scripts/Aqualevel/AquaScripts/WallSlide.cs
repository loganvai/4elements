using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlide : MonoBehaviour
{
    // Start is called before the first frame update
    public float distance = 2f;
    PlayerMovement player;
    public float speed = 2f;
    void Start()
    {
        player = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.left * transform.localScale.x, distance);

        if (!player.isGrounded && (hit.collider != null || hit2.collider !=null))
        {
            if (GetComponent<Rigidbody2D>().velocity.y < speed)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            }
        }
        
    }
}

