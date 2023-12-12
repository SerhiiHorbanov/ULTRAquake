using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Collider))]
    public class GroundCheck : MonoBehaviour
    {
        public bool isOnGround
            => framesOffGround == 0;
        public bool isOnGroundWithCoyoteTime
            => framesOffGround <= coyoteTimeFrames;

        [Tooltip("how many frames off ground player has to be to for isOnGround be false")]
        [SerializeField] private int coyoteTimeFrames;
        private int framesOffGround = 0;

        List<Collider> collidingWith = new List<Collider>();

        void FixedUpdate()
        {
            if (collidingWith.Count > 0)//if colliding with anything
            {
                framesOffGround = 0;
                return;
            }

            framesOffGround++;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!collidingWith.Contains(collision.collider))
                collidingWith.Add(collision.collider);
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collidingWith.Contains(collision.collider))
                collidingWith.Remove(collision.collider);
        }
    }
}
