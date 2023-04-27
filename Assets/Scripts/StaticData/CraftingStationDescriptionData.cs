using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "CraftingStationDescriptionData", menuName = "StaticData/CraftingStationDescription")]
    public class CraftingStationDescriptionData : ScriptableObject
    {
        [SerializeField] [TextArea] private string defaultIngredientText;
        [SerializeField] [TextArea] private string defaultResultText;
        [SerializeField] [TextArea] private string notEnoughItemsResultText;
        [SerializeField] [TextArea] private string wrongItemsResultText;

        public string DefaultIngredientText => defaultIngredientText;

        public string DefaultResultText => defaultResultText;

        public string NotEnoughItemsResultText => notEnoughItemsResultText;

        public string WrongItemsResultText => wrongItemsResultText;
    }
}