using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void StartInteract(PlayerController player);
    void StopInteract(PlayerController player);
}
