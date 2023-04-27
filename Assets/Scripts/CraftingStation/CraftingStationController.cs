using System.Collections.Generic;
using Infrastructure.Factories;
using Infrastructure.Services;
using Ingredients;
using StaticData;
using UIElements;
using UnityEngine;

namespace CraftingStation
{
    public class CraftingStationController : MonoBehaviour
    {
        [SerializeField] private CraftButton craftButton;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private IngredientChamber chamber;
        [SerializeField] private CraftReceiptDescription description;
        private IGameFactory gameFactory;
        private IStaticDataService staticDataService;
        private CraftResult craftResult;


        public void Construct()
        {
            gameFactory = ServiceLocator.Container.Single<IGameFactory>();
            staticDataService = ServiceLocator.Container.Single<IStaticDataService>();
            craftResult = new CraftResult(staticDataService);
            craftButton.Init();
            craftButton.OnButtonClick += OnButtonClickHandler;
            chamber.OnUpdateIngredients += OnUpdateIngredientsHandler;
            description.Construct(gameFactory, staticDataService);
        }

        private void OnUpdateIngredientsHandler(List<Ingredient> ingredients)
        {
            var resultData = craftResult.GetReceiptResultData(ingredients);
            description.SetResultDescription(ingredients, resultData);
            description.SetIngredientsDescription(ingredients);
        }

        private void OnButtonClickHandler()
        {
            var resultData = craftResult.GetReceiptResultData(chamber.IngredientsInChamber);
            if (resultData != null)
            {
                chamber.DeleteObjectsInChamber();
                gameFactory.CreateIngredient(resultData.TypeId, spawnPoint.position);
                description.RefreshStatus();
            }
        }
    }
}