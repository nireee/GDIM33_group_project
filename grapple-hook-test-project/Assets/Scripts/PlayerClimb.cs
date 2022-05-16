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
        if (Input.GetKey(KeyCode.W) && _timeSinceClimbed >= _climbRate)
        {
            _timeSinceClimbed = 0;

            GrappleHookLauncher._instance.RemoveLastLink();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            // implement descending the grapple hook by adding another rope link to the end and connecting it to the player
        }

        _timeSinceClimbed += Time.deltaTime;
    }
}
