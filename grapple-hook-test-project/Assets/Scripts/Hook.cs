using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : Link
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "CanGrapple" && !GrappleHookLauncher._instance._hookLanded)
        {
            GrappleHookLauncher._instance._hookLanded = true;

            // maybe set rotation so the hook is pointing towards the object it's attached to

            _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
