using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "IngredientData", menuName = "StaticData/Ingredient")]
    public class IngredientsStaticData : ScriptableObject
    {
        [SerializeField] private IngredientTypeId typeID;
        [SerializeField] private GameObject prefab;
        [SerializeField] [TextArea] private string description;

        public IngredientTypeId TypeId => typeID;
        public GameObject Prefab => prefab;
        public string Description => description;
    }
}