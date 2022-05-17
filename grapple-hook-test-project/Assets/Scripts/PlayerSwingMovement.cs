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
    private Rigidbody2D _rigidbody;

    private float _xInput;

    private void Start()
    {
        _currentSpeedForce = _maxSpeedForce;
    }

    // Update is called once per frame
    private void Update()
    {
        _xInput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if (GrappleHookLauncher._instance._hookLanded && (_xInput <= -.1 || _xInput >= .1))
        {
            _rigidbody.AddForce(new Vector2(_xInput * _currentSpeedForce, 0));

            _currentSpeedForce -= _speedLossRate;
        }
        else
        {
            _currentSpeedForce += _speedGainRate;
        }

        _currentSpeedForce = Mathf.Clamp(_currentSpeedForce, 0, _maxSpeedForce);

        print(_currentSpeedForce);
    }
}
