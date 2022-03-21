using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Movement : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private const string VectorX = "VectorX";
    private Vector2 _moveVector;
    private float _moveSpeed = 5f;
    private bool _faceRight = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Run();
    }

    private void Run()
    {
        _moveVector.x = Input.GetAxis("Horizontal");
        _animator.SetFloat(VectorX, Mathf.Abs(_moveVector.x));
        _rigidbody.velocity = new Vector2(_moveVector.x * _moveSpeed, _rigidbody.velocity.y);

        if (_faceRight == true && _moveVector.x < 0)
        {
            Flip();
        }
        else if (_faceRight == false && _moveVector.x > 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _faceRight = !_faceRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}

