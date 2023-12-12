using UnityEngine;

namespace Player.Movement
{
    [RequireComponent(typeof(GroundCheck))]
    [RequireComponent(typeof(Rigidbody))]
    public class Jump : MonoBehaviour
    {
        [SerializeField] GroundCheck groundCheck;
        [SerializeField] Rigidbody rigidBody;

        [Tooltip("vertical velocity that will be added to player when initiating jump... i mean just the force of a jump")]
        [SerializeField] float jumpSpeed;

        public bool isJumping = false;

        Vector3 Velocity
        {
            get
                => rigidBody.velocity;
            set
                => rigidBody.velocity = value;
        }

        private void Update()
        {
            if (isJumping)
                TryStartJump();
        }

        public void TryStartJump()
        {
            if (groundCheck.isOnGroundWithCoyoteTime)
                StartJump();
        }

        private void StartJump()
        {
            if (Velocity.y < jumpSpeed)
                Velocity = new Vector3(Velocity.x, jumpSpeed, Velocity.z);
        }
    }
}
