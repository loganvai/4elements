using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishForce : MonoBehaviour
{
     Rigidbody2D rb2d;
    int i = 1;
    public float speedx;
    public float speedy;
    public bool destroy;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(speedx, speedy);    
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Border" || collision.gameObject.tag == "Ground")
            if (i==0)
                if(gameObject!=null)
            {
                Destroy(gameObject);
                    i = 1;
           
            }
            i--;
       
    }
}
