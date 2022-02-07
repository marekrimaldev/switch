using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionGroundChecker : GroundCheckerBase
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsGrounded = true;
        OnGroundEnter?.Invoke();
    }
}
