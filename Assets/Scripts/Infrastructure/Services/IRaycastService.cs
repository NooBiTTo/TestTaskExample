using UnityEngine;

namespace Infrastructure.Services
{
    public interface IRaycastService : IService
    {
        T GetObjectOfType<T>(Vector3 aimPoint, Vector3 raycastEndPosition) where T : class;
    }
}