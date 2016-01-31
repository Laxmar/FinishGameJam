using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;
using System;
using UnityEditor;

[RequireComponent(typeof(Rigidbody2D))]
public class Kontroler : MonoBehaviour {


    public float JumpForce = 5f;
    public float SpeedConstant = 1f;
    public float MaxSpeed = 6f;
	public Canvas Kanwas;
	public bool isShowing = false;

	public Vector3 CheckpointPosition = new Vector3 (0, 0, 0);

    Rigidbody2D _rigidbody2D;
    bool _jump;
    bool _canJump = true;
    bool _afterFirstJump = false;
    bool _jumpAfterContact = false;
    private bool _facingRight = true;
    Vector2 _contactVector = new Vector2(0,0);
    private Animator _animator;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
		Kanwas.gameObject.SetActive (isShowing);
    }

    void Update()
    {
		if(Input.GetKeyDown("escape"))
		{
			isShowing = !isShowing;
			Kanwas.gameObject.SetActive(isShowing);
		}

        _jump = false;

        if (Input.GetButtonDown("Jump") || Input.GetButtonUp("Jump"))
        { 
            _jump = true;
            _animator.SetTrigger("Jump");
        }
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        _animator.SetFloat("Speed", Mathf.Max( Mathf.Abs(move), _rigidbody2D.velocity.magnitude));

        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x + (move * SpeedConstant), _rigidbody2D.velocity.y);

        if (_rigidbody2D.velocity.x > MaxSpeed)
        {
            _rigidbody2D.velocity = new Vector2(MaxSpeed, _rigidbody2D.velocity.y);
        }
        else if (_rigidbody2D.velocity.x < -MaxSpeed)
        {
            _rigidbody2D.velocity = new Vector2(-MaxSpeed, _rigidbody2D.velocity.y);
        }

        if (move > 0 && !_facingRight)
            Flip();
        else if (move < 0 && _facingRight)
            Flip();

       JumpAction();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if(Mathf.Abs(contact.normal.x)> 0.5 && _contactVector.x != contact.normal.x)
                _jumpAfterContact = false;

            _contactVector = contact.normal;

            if (contact.normal.y > 0.5)
            {
                _canJump = true;
                _afterFirstJump = false;
            }
        }
		if (collision.gameObject.tag == "Checkpoint") {
			CheckpointPosition = new Vector3 (collision.gameObject.transform.position.x, collision.gameObject.transform.position.y + 5, 0);
		}
		if (collision.gameObject.tag == "Enemy") {
			_rigidbody2D.transform.position = CheckpointPosition;
		}
    }

    void JumpAction()
    {
        if (_afterFirstJump && Mathf.Abs(_contactVector.x) > 0.5 && !_jumpAfterContact && _jump)
        {
            _rigidbody2D.velocity = new Vector2(JumpForce * _contactVector.x, _rigidbody2D.velocity.y + JumpForce);
            _jumpAfterContact = true;
            return;
        }

        if (_jump && _canJump)
        {
            _jump = false;
            
            _canJump = false;
            
            _afterFirstJump = true;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _rigidbody2D.velocity.y + JumpForce);
        }
    }

    void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}


