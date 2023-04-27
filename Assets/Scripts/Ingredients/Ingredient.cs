using StaticData;
using UnityEngine;

namespace Ingredients
{
    public class Ingredient : MonoBehaviour
    {
        [SerializeField] private IngredientTypeId type;
        public IngredientTypeId Type => type;
    }
}