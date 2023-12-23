using UnityEngine;
using UnityEngine.InputSystem;
using Player.Movement;
using Weapons;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Jump jump;
        [SerializeField] Walk walk;
        [SerializeField] PlayerCamera look;
        [SerializeField] WeaponManager weaponManager;

        Vector2 walkDirection = Vector2.zero;

        public void ChangeWalkDirection(InputAction.CallbackContext context)
        {
            walkDirection = context.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            walk.SetRelativeWalkDirection(walkDirection);
        }

        public void TryStartJump(InputAction.CallbackContext context)
        {
            jump.isJumping = context.phase.IsInProgress();
        }

        public void RotateLook(InputAction.CallbackContext context)
        {
            look.MouseLook(context.ReadValue<Vector2>());
        }

        public void TryAttack(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Started)
                weaponManager.Attack();
        }
    }
}
