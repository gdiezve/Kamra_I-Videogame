using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    
    public float initialPosition;
    public float speed;
    public float movementRange = 1f;
    public bool lookingRight = false;
    public GameObject player;
    public GameObject foot;
    public bool isDying = false;

    Rigidbody2D rb;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = this.transform.position.x;
        rb = GetComponent <Rigidbody2D>();
        animator = GetComponent <Animator> ();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (lookingRight) {
            if (this.transform.position.x > initialPosition + movementRange) {
                lookingRight = false;
                this.transform.localScale = new Vector3 (4.5f, 4.5f, 4.5f);
            } else {
                this.rb.velocity = new Vector3 (speed, rb.velocity.y, 0);
                animator.SetFloat("speed", speed);
            }
        } else {
            if (this.transform.position.x < initialPosition - movementRange) {
                lookingRight = true;
                this.transform.localScale = new Vector3 (-4.5f, 4.5f, 4.5f);
            } else {
                this.rb.velocity = new Vector3 (-speed, rb.velocity.y, 0);
                animator.SetFloat("speed", speed);
            }
        }

        if (isDying) {
            rb.velocity = Vector3.zero;
        }
    }

    void OnCollisionEnter2D (Collision2D other) {
        if (lookingRight) {
            this.transform.localScale = new Vector3 (4.5f, 4.5f, 4.5f);
            lookingRight = false;
        } else {
            this.transform.localScale = new Vector3 (-4.5f, 4.5f, 4.5f);
            lookingRight = true;
        }

        if (player.gameObject.GetComponent <Player>().isOnEnemy == true) {
            isDying = true;
            animator.SetBool("isDying", isDying);
            Destroy(this.gameObject, 2);
        }
    }
}
