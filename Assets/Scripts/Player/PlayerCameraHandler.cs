using UnityEngine;

namespace Player
{
    public class PlayerCameraHandler : MonoBehaviour
    {
        [SerializeField] private Transform cameraRoot;
        public Transform CameraRoot => cameraRoot;
    }
}