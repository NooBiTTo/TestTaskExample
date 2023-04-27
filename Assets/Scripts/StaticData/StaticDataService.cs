using System.Collections.Generic;
using System.Linq;
using Infrastructure.AssetManagement;
using UnityEngine;

namespace StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<IngredientTypeId, IngredientsStaticData> ingredients;
        private Dictionary<string, LevelStaticData> levels;
        private ReceiptsData receipts;
        private CraftingStationDescriptionData craftingStationDescription;
        public ReceiptsData Receipts => receipts;
        public CraftingStationDescriptionData CraftingStationDescription => craftingStationDescription;

        public void LoadData()
        {
            ingredients = Resources
                .LoadAll<IngredientsStaticData>(AssetPath.IngredientsStaticDataPath)
                .ToDictionary(x => x.TypeId, x => x);
            levels = Resources
                .LoadAll<LevelStaticData>(AssetPath.LevelsStaticDataPath)
                .ToDictionary(x => x.LevelKey, x => x);
            receipts = Resources.Load<ReceiptsData>(AssetPath.ReceiptsDataPath);
            craftingStationDescription =
                Resources.Load<CraftingStationDescriptionData>(AssetPath.CraftingStationDescriptionPath);
        }

        public LevelStaticData ForLevel(string sceneKey)
        {
            return levels.TryGetValue(sceneKey, out LevelStaticData staticData) ? staticData : null;
        }

        public IngredientsStaticData ForIngredients(IngredientTypeId typeID)
        {
            return ingredients.TryGetValue(typeID, out IngredientsStaticData staticData) ? staticData : null;
        }
    }
}