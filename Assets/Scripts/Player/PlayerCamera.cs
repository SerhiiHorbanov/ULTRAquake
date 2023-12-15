using UnityEngine;

namespace Player
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] Transform cameraTransform;

        [SerializeField] float sensitivity;

        public void MouseLook(Vector2 delta)
            => RotateLook(delta * sensitivity);

        public void RotateLook(Vector2 rotation)
        {
            Vector3 newCameraRotationEuler = cameraTransform.localRotation.eulerAngles + new Vector3(-rotation.y, 0, 0);
            cameraTransform.localRotation = Quaternion.Euler(newCameraRotationEuler);

            transform.Rotate(0, rotation.x, 0);
        }
    }
}
