using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwingMovement : MonoBehaviour
{
    [SerializeField]
    private float _maxSpeedForce;

    [SerializeField]
    private float _speedGainRate;

    [SerializeField]
    private float _speedLossRate;

    private float _currentSpeedForce;

    [SerializeField]
    private SpriteRenderer _sprite;

    [SerializeField]
    private Rigidbody2D _rigidbody;

    [SerializeField]
    private Transform _groundCheck;

    [SerializeField]
    private LayerMask _groundLayer;

    private float _groundCheckRadius = .1f;

    private Collider2D[] _groundCheckColliders;
    
    private float _xInput;

    private void Start()
    {
        _currentSpeedForce = _maxSpeedForce;
    }

    // Update is called once per frame
    private void Update()
    {
        _xInput = Input.GetAxisRaw("Horizontal");

        _groundCheckColliders = Physics2D.OverlapCircleAll(_groundCheck.position, _groundCheckRadius, _groundLayer);
    }

    private void FixedUpdate()
    {
        if (GrappleHookLauncher._instance._hookLanded && (_xInput <= -.1 || _xInput >= .1) && _groundCheckColliders.Length == 0)
        {
            _rigidbody.AddForce(new Vector2(_xInput * _currentSpeedForce, 0));

            _currentSpeedForce -= _speedLossRate;

            if (_xInput >= .1)
                _sprite.flipX = false;
            else
            {
                _sprite.flipX = true;
            }
        }
        else
        {
            _currentSpeedForce += _speedGainRate;
        }

        _currentSpeedForce = Mathf.Clamp(_currentSpeedForce, 0, _maxSpeedForce);
    }
}
