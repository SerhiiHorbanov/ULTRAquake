using Player;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class NetworkPlayerController : NetworkBehaviour
{
    [SerializeField] PlayerController controller;

    public void ChangeWalkDirection(InputAction.CallbackContext context)
    {
        if(IsOwner)
            controller.ChangeWalkDirection(context);
    }

    public void RotateLook(InputAction.CallbackContext context)
    {
        if (IsOwner)
            controller.RotateLook(context);
    }

    public void TryAttack(InputAction.CallbackContext context)
    {
        if (IsOwner)
            controller.TryAttack(context);
    }

    public void TryStartJump(InputAction.CallbackContext context)
    {
        if (IsOwner)
            controller.TryStartJump(context);
    }
}
