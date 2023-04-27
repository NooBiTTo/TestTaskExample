using Cinemachine;
using UnityEngine;

namespace Infrastructure.Services
{
    public class CameraService : ICameraService
    {
        private Camera playerCamera;
        public Camera PlayerCamera => playerCamera;

        public void SetPlayerCamera(Camera playerCamera)
        {
            this.playerCamera = playerCamera;
        }

        public void SetCameraFollowTo(Transform cameraRoot, GameObject virtualCameraGameObject)
        {
            if (virtualCameraGameObject.TryGetComponent(out CinemachineVirtualCameraBase virtualCamera))
            {
                virtualCamera.Follow = cameraRoot;
            }
        }
    }
}