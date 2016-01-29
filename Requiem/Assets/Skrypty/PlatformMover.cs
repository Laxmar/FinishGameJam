using UnityEngine;
using System.Collections;
using UnityEditor;

// StartPostiion LEft or down
// End postion right or top
public class PlatformMover : MonoBehaviour
{
    public Transform StartPosition;
    public Transform EndPosition;
    public float Speed;
    public bool VerticalMove;
    public bool HorizontalMove;

    private Rigidbody2D _rigidbody2D;
    private bool _movingToEnd = true;


    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (VerticalMove)
            MoveVertical();
        if (HorizontalMove)
            MoveHorizontal();
    }

    void Update () {

	}

    void MoveHorizontal()
    {
        if (_rigidbody2D.position.x >= EndPosition.position.x)
        {
            _movingToEnd = false;
        }
        if (_rigidbody2D.position.x <= StartPosition.position.x)
        {
            _movingToEnd = true;
        }


        if (_movingToEnd)
        {
            _rigidbody2D.MovePosition(_rigidbody2D.position + Vector2.right * Speed);
        }
        else
        {
            _rigidbody2D.MovePosition(_rigidbody2D.position + Vector2.left * Speed);
        }
    }

    void MoveVertical()
    {
        if (_rigidbody2D.position.y >= EndPosition.position.y)
            _movingToEnd = false;
        if (_rigidbody2D.position.y <= StartPosition.position.y)
            _movingToEnd = true;

        if (_movingToEnd)
        {
            _rigidbody2D.MovePosition(_rigidbody2D.position + Vector2.up *Speed);
        }
        else
        {
            _rigidbody2D.MovePosition(_rigidbody2D.position + Vector2.down *Speed);
        }
    }
}
