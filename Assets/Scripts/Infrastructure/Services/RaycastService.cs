using Infrastructure.AssetManagement;
using UnityEngine;

namespace Infrastructure.Services
{
    public class RaycastService : IRaycastService
    {
        private ICameraService cameraService;
        private RaycastSettings settings;

        public RaycastService(ICameraService cameraService)
        {
            this.cameraService = cameraService;
            settings = Resources.Load<RaycastSettings>(AssetPath.RaycastSettingsPath);
        }

        public T GetObjectOfType<T>(Vector3 aimPoint, Vector3 raycastEndPosition) where T : class
        {
            RaycastHit hit;
            T result = null;
            Camera camera = cameraService.PlayerCamera;
            Ray ray = camera.ScreenPointToRay(aimPoint);
            Vector3 cameraPosition = camera.transform.position;
            var rayLength = Vector3.Distance(cameraPosition, raycastEndPosition);
            Debug.DrawLine(cameraPosition, raycastEndPosition, Color.red);
            if (Physics.Raycast(ray, out hit, rayLength, settings.Mask))
            {
                Transform objectHit = hit.transform;
                if (objectHit.gameObject.TryGetComponent(out T component))
                {
                    result = component;
                }
            }

            return result;
        }
    }
}