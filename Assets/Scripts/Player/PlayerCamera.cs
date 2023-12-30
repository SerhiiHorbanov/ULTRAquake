using UnityEngine;

namespace Player
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] Transform cameraTransform;

        [SerializeField] float sensitivity;
        [SerializeField] float maxXRotation = 90;//X axis rotation is up and down
        [SerializeField] float minXRotation = -90;//X axis rotation is up and down
        public void MouseLook(Vector2 delta)
            => RotateLook(delta * sensitivity);

        public void RotateLook(Vector2 rotation)
        {
            Vector3 newCameraRotationEuler = cameraTransform.localRotation.eulerAngles;
            newCameraRotationEuler.x += -rotation.y;

            if (newCameraRotationEuler.x > 180)//it's for easier calculations
                newCameraRotationEuler.x -= 360;

            newCameraRotationEuler.x = Mathf.Clamp(newCameraRotationEuler.x, minXRotation, maxXRotation);

            Debug.Log($"newCameraRotationEuler = {newCameraRotationEuler}");

            cameraTransform.localRotation = Quaternion.Euler(newCameraRotationEuler);

            transform.Rotate(0, rotation.x, 0);
        }
    }
}
