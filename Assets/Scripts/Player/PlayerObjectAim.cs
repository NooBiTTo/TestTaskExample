using Infrastructure.Services;
using UnityEngine;

namespace Player
{
    public class PlayerObjectAim
    {
        private readonly RectTransform crosshair;
        private readonly Transform endAimPoint;
        private readonly IRaycastService raycastService;

        public PlayerObjectAim(RectTransform crosshair, Transform endAimPoint, IRaycastService raycastService)
        {
            this.crosshair = crosshair;
            this.endAimPoint = endAimPoint;
            this.raycastService = raycastService;
        }

        public T GetAimedObject<T>() where T : class
        {
            Vector3 raycastEndPosition = endAimPoint.transform.position;
            var raycastedComponent = raycastService.GetObjectOfType<T>(crosshair.position, raycastEndPosition);
            return raycastedComponent;
        }
    }
}