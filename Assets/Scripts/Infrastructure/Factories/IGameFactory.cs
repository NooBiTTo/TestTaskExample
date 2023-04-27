using Infrastructure.Services;
using StaticData;
using UnityEngine;

namespace Infrastructure.Factories
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayer(Vector3 at);
        GameObject CreateCraftStation(Vector3 at);
        GameObject CreateIngredient(IngredientTypeId typeId, Vector3 at);
        GameObject CreateVirtualCamera();
        GameObject CreatePlayerCamera();
        GameObject CreateIngredientDescription();
    }
}