using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Kontroler : MonoBehaviour {


    public float jumpForce = 5f;
    public float speedConstant = 1f;
    public float maxSpeed = 6f;

    bool jump;
    bool canJump = true;
    bool afterFirstJump = false;
    bool jumpAfterContact = false;

    Rigidbody2D rb2;


    Vector2 contactVector = new Vector2(0,0);


    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {

            if(Mathf.Abs(contact.normal.x)> 0.5 && contactVector.x != contact.normal.x)
                jumpAfterContact = false;

            contactVector = contact.normal;

            if (contact.normal.y > 0.5)
            {
                canJump = true;
                afterFirstJump = false;
                
            }

        }
    }

    // Use this for initialization
    void Start () {
        rb2 = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        jump = false;

        if (Input.GetButtonDown("Jump") || Input.GetButtonUp("Jump"))
        {
            jump = true;
        }
 
    }

    void FixedUpdate()
    {

        float move = Input.GetAxis("Horizontal");


        rb2.velocity = new Vector2(rb2.velocity.x + (move * speedConstant), rb2.velocity.y);

        if (rb2.velocity.x > maxSpeed)
        {
            rb2.velocity = new Vector2(maxSpeed, rb2.velocity.y);
        }
        else if (rb2.velocity.x < -maxSpeed)
        {
            rb2.velocity = new Vector2(-maxSpeed, rb2.velocity.y);
        }

            jumpAction();

    }

    void jumpAction()
    {

        if (afterFirstJump && Mathf.Abs(contactVector.x) > 0.5 && !jumpAfterContact && jump)
        {
            rb2.velocity = new Vector2(jumpForce * contactVector.x, rb2.velocity.y + jumpForce);
            jumpAfterContact = true;
            return;
        }


        if (jump && canJump)
        {
            jump = false;
            canJump = false;
            
            afterFirstJump = true;
            rb2.velocity = new Vector2(rb2.velocity.x, rb2.velocity.y + jumpForce);

        }
    }
}


