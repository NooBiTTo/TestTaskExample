using UnityEngine;

namespace Infrastructure.Services
{
    [CreateAssetMenu(fileName = "RaycastSettings", menuName = "Services Settings/Raycast")]
    public class RaycastSettings : ScriptableObject
    {
        [SerializeField] private LayerMask layerMask;
        public LayerMask Mask => layerMask;
    }
}