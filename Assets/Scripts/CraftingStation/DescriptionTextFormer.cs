using System.Collections.Generic;
using Ingredients;
using StaticData;

namespace CraftingStation
{
    public class DescriptionTextFormer
    {
        private IStaticDataService staticDataService;
        private CraftingStationDescriptionData descriptionData;

        public DescriptionTextFormer(IStaticDataService staticDataService)
        {
            this.staticDataService = staticDataService;
            descriptionData = this.staticDataService.CraftingStationDescription;
        }

        public string GetResultRefreshedText()
        {
            return descriptionData.DefaultResultText;
        }

        public string GetIngredientsRefreshedText()
        {
            return descriptionData.DefaultIngredientText;
        }

        public string GetResultDescriptionText(List<Ingredient> ingredientsInChamber, IngredientsStaticData resultData)
        {
            if (NoObjectsInChamber(ingredientsInChamber))
            {
                return descriptionData.DefaultResultText;
            }

            if (OnlyOneObjectInChamber(ingredientsInChamber))
            {
                return descriptionData.NotEnoughItemsResultText;
            }

            if (resultData == null)
            {
                return descriptionData.WrongItemsResultText;
            }
            else
            {
                return resultData.Description;
            }
        }

        public List<string> GetIngredientsDescriptionText(List<Ingredient> ingredientsInChamber)
        {
            List<string> text = new List<string>();
            if (NoObjectsInChamber(ingredientsInChamber))
            {
                text.Add(descriptionData.DefaultIngredientText);
            }

            foreach (var ingredient in ingredientsInChamber)
            {
                IngredientsStaticData ingredientsData = staticDataService.ForIngredients(ingredient.Type);
                text.Add(ingredientsData.Description);
            }

            return text;
        }

        private bool OnlyOneObjectInChamber(List<Ingredient> ingredientsInChamber)
        {
            return ingredientsInChamber.Count == 1;
        }

        private bool NoObjectsInChamber(List<Ingredient> ingredientsInChamber)
        {
            return ingredientsInChamber.Count == 0;
        }
    }
}