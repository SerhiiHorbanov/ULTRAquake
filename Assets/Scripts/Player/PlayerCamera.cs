using UnityEngine;

namespace Player
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] Transform cameraTransform;

        [SerializeField] float sensitivity;

        public void RotateLook(Vector2 delta)
        {
            delta *= sensitivity;

            cameraTransform.localRotation = Quaternion.Euler(cameraTransform.localRotation.eulerAngles.x - delta.y, 0, 0);

            transform.Rotate(0, delta.x, 0);
        }
    }
}
