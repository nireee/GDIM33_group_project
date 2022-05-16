using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : Link
{
    private Vector3 _lockedPosition;

    private void LateUpdate()
    {
        if (GrappleHookLauncher._instance._hookLanded)
            transform.position = _lockedPosition;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "CanGrapple" && !GrappleHookLauncher._instance._hookLanded)
        {
            GrappleHookLauncher._instance._hookLanded = true;

            // maybe set rotation so the hook is pointing towards the object it's attached to

            _lockedPosition = transform.position;
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
