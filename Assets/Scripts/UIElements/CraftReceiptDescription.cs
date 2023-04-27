using System.Collections.Generic;
using CraftingStation;
using Infrastructure.Factories;
using Ingredients;
using StaticData;
using TMPro;
using UnityEngine;

namespace UIElements
{
    public class CraftReceiptDescription : MonoBehaviour
    {
        [SerializeField] private TextMeshPro resultDescription;
        [SerializeField] private IngredientDescription ingredientDescription;

        private DescriptionTextFormer textFormer;

        public void Construct(IGameFactory gameFactory, IStaticDataService staticDataService)
        {
            ingredientDescription.Construct(gameFactory);
            textFormer = new DescriptionTextFormer(staticDataService);
            RefreshStatus();
        }

        public void RefreshStatus()
        {
            SetResultDescription(textFormer.GetResultRefreshedText());
            DeleteIngredientDescription();
            AddIngredientDescription(textFormer.GetIngredientsRefreshedText());
        }

        public void SetResultDescription(List<Ingredient> ingredientsInChamber, IngredientsStaticData resultData)
        {
            string descriptionText = textFormer.GetResultDescriptionText(ingredientsInChamber, resultData);
            SetResultDescription(descriptionText);
        }

        public void SetIngredientsDescription(List<Ingredient> ingredients)
        {
            DeleteIngredientDescription();
            var descriptionTexts = textFormer.GetIngredientsDescriptionText(ingredients);
            foreach (var descriptionText in descriptionTexts)
            {
                AddIngredientDescription(descriptionText);
            }
        }

        private void SetResultDescription(string content)
        {
            resultDescription.text = content;
        }

        private void AddIngredientDescription(string content)
        {
            ingredientDescription.AddDescription(content);
        }

        private void DeleteIngredientDescription()
        {
            ingredientDescription.DeleteDescription();
        }
    }
}