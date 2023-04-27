using System.Collections.Generic;
using System.Linq;
using Ingredients;
using StaticData;

namespace CraftingStation
{
    public class CraftResult
    {
        private ReceiptsData receipts;
        private IStaticDataService staticDataService;

        public CraftResult(IStaticDataService staticDataService)
        {
            this.staticDataService = staticDataService;
            receipts = staticDataService.Receipts;
        }

        public IngredientsStaticData GetReceiptResultData(List<Ingredient> ingredientsInChamber)
        {
            foreach (var currentReceipt in receipts.Content)
            {
                if (IsNumberInChamberAndReceiptAreEqual(ingredientsInChamber, currentReceipt))
                {
                    bool isWrongReceipt = false;
                    foreach (var currentIngredientType in currentReceipt.Ingredients)
                    {
                        if (isWrongReceipt) break;
                        isWrongReceipt = IsCountInChamberAndReceiptAreDifferent(ingredientsInChamber, currentReceipt,
                            currentIngredientType);
                    }

                    if (!isWrongReceipt)
                    {
                        return staticDataService.ForIngredients(currentReceipt.Result);
                    }
                }
            }

            return null;
        }

        private bool IsNumberInChamberAndReceiptAreEqual(List<Ingredient> ingredientsInChamber,
            ReceiptData currentReceipt)
        {
            return currentReceipt.Ingredients.Count == ingredientsInChamber.Count;
        }

        private bool IsCountInChamberAndReceiptAreDifferent(List<Ingredient> ingredientsInChamber, ReceiptData receipt,
            IngredientTypeId ingredientType)
        {
            var countInReceipt = receipt.Ingredients
                .Count(receiptIngredientType => receiptIngredientType == ingredientType);

            var countInChamber = ingredientsInChamber.Count(ingredientInChamber =>
                ingredientInChamber.Type == ingredientType);

            if (countInChamber != countInReceipt)
            {
                return true;
            }

            return false;
        }
    }
}