using StaticData;
using UnityEngine;

namespace Logic
{
    public class IngredientSpawnMarker : MonoBehaviour
    {
        [SerializeField] private IngredientTypeId typeId;
        public IngredientTypeId TypeId => typeId;
    }
}