using CraftingStation;
using Infrastructure.AssetManagement;
using Infrastructure.Services;
using StaticData;
using UIElements;
using UnityEngine;

namespace Infrastructure.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider assets;
        private readonly IStaticDataService staticData;
        private readonly ICameraService cameraService;
        private GameObject playerGameObject;

        public GameFactory(IAssetProvider assets, IStaticDataService staticData, ICameraService cameraService)
        {
            this.assets = assets;
            this.staticData = staticData;
            this.cameraService = cameraService;
        }

        public GameObject CreatePlayerCamera()
        {
            var prefabPath = AssetPath.PlayerCameraPath;
            playerGameObject = assets.Instantiate(prefabPath);
            return playerGameObject;
        }

        public GameObject CreatePlayer(Vector3 at)
        {
            var prefabPath = AssetPath.PlayerPath;
            Vector3 position = at;
            playerGameObject = assets.Instantiate(prefabPath, position);
            return playerGameObject;
        }

        public GameObject CreateVirtualCamera()
        {
            var prefabPath = AssetPath.VirtualCameraPath;
            var cameraFollowGameObject = assets.Instantiate(prefabPath);
            return cameraFollowGameObject;
        }

        public GameObject CreateCraftStation(Vector3 at)
        {
            var prefabPath = AssetPath.CraftingStationPath;
            Vector3 position = at;
            var craftStationGameObject = assets.Instantiate(prefabPath, position);
            craftStationGameObject.GetComponent<CraftingStationController>().Construct();
            return craftStationGameObject;
        }

        public GameObject CreateIngredient(IngredientTypeId typeId, Vector3 at)
        {
            IngredientsStaticData ingredientData = staticData.ForIngredients(typeId);
            GameObject prefab = ingredientData.Prefab;
            Vector3 position = at;
            var ingredientGameObject = Object.Instantiate(prefab, position, Quaternion.identity);
            var interactableUIGameObject = CreateInteractableUI(ingredientGameObject.transform);

            if (ingredientGameObject.TryGetComponent(out InteractableUIController ingredient) &&
                interactableUIGameObject.TryGetComponent(out InteractableUI interactableUI))
            {
                ingredient.Construct(interactableUI, playerGameObject.transform);
            }

            return ingredientGameObject;
        }

        public GameObject CreateIngredientDescription()
        {
            var prefabPath = AssetPath.IngredientDescriptionPath;
            var ingredientDescriptionGameObject = assets.Instantiate(prefabPath);
            return ingredientDescriptionGameObject;
        }

        private GameObject CreateInteractableUI(Transform parent)
        {
            var prefabPath = AssetPath.InteractableUIPath;
            var interactableUIGameObject = assets.Instantiate(prefabPath);
            interactableUIGameObject.transform.parent = parent;
            interactableUIGameObject.transform.localPosition = Vector3.zero;
            interactableUIGameObject.transform.localRotation = Quaternion.identity;

            if (interactableUIGameObject.TryGetComponent(out LookAtCamera lookAtComponent))
            {
                lookAtComponent.Construct(cameraService.PlayerCamera);
            }

            return interactableUIGameObject;
        }
    }
}