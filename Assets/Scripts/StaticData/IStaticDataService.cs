using Infrastructure.Services;

namespace StaticData
{
    public interface IStaticDataService : IService
    {
        ReceiptsData Receipts { get; }
        CraftingStationDescriptionData CraftingStationDescription { get; }
        void LoadData();
        LevelStaticData ForLevel(string sceneKey);
        IngredientsStaticData ForIngredients(IngredientTypeId typeID);
    }
}