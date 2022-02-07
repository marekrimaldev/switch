using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GroundCheckerBase : MonoBehaviour
{
    public System.Action OnGroundEnter;

    public bool IsGrounded { get; set; } = false;
}
