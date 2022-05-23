using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimb : MonoBehaviour
{
    [SerializeField]
    private float _climbRate;

    [SerializeField]
    private float _descendRate;

    private float _timeSinceClimbed;

    private float _timeSinceDescended;

    private void Start()
    {
        _timeSinceClimbed = _climbRate;
        _timeSinceDescended = _descendRate;
    }

    private void Update()
    {
        if (_timeSinceClimbed < _climbRate)
        {
            _timeSinceClimbed += Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            _timeSinceClimbed = 0;

            GrappleHookLauncher._instance.Climb();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            // implement descending the grapple hook by adding another rope link to the end and connecting it to the player
            _timeSinceClimbed = 0;

            GrappleHookLauncher._instance.Descend();
        }
    }
}
