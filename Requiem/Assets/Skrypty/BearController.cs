using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

[RequireComponent(typeof(Rigidbody2D))]
public class BearController : MonoBehaviour
{

    public float SpeedConstant;

    private bool _facingRight = false;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;


	void Start ()
	{
	    _rigidbody2D = GetComponent<Rigidbody2D>();
	    _animator = GetComponent<Animator>();
        if(!_facingRight) 
            Flip();
	}
	
	void FixedUpdate ()
	{
	    float move = Input.GetAxis("Horizontal");

        _animator.SetFloat("Speed", Mathf.Abs(move));
        
       _rigidbody2D.velocity = new Vector3(move * SpeedConstant, _rigidbody2D.velocity.y);

	    if (move > 0 && !_facingRight)
            Flip();
        else if( move < 0 && _facingRight)
            Flip();

	}

    void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}
