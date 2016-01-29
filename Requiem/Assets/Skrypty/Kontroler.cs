using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;
using System;

public class Kontroler : MonoBehaviour {

    Rigidbody2D rb2;

    float speedConstant = 4f;
    float jumpForce = 6f;
    bool jump;

    float maxSpeed = 10f;
    float jumpTreshold = 0.5f;

    // Use this for initialization
    void Start () {
        rb2 = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(rb2.velocity.y) < jumpTreshold)
        {
            jump = Input.GetButtonDown("Jump");
        }
    }

    void FixedUpdate()
    {

        float move = Input.GetAxis("Horizontal");
        Vector2 move_vector = new Vector2(0,0);


        if (Mathf.Abs(rb2.velocity.x) < maxSpeed)
        {
            if (jump)
            {
                move_vector = new Vector2(move * speedConstant, jumpForce);
                jump = false;
            }
            else
                move_vector = new Vector2(move * speedConstant, rb2.velocity.y);
        }

        rb2.velocity = move_vector;
        
    }


}

