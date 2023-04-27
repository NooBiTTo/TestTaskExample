using UnityEngine;

namespace Infrastructure.Services
{
    public interface ICameraService : IService
    {
        Camera PlayerCamera { get; }
        void SetCameraFollowTo(Transform cameraRoot, GameObject virtualCameraGameObject);
        void SetPlayerCamera(Camera playerCamera);
    }
}