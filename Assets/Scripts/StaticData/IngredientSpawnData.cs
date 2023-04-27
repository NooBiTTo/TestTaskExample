using System;
using UnityEngine;

namespace StaticData
{
    [Serializable]
    public class IngredientSpawnData
    {
        [SerializeField] private IngredientTypeId ingredientTypeId;
        [SerializeField] private Vector3 position;

        public Vector3 Position => position;
        public IngredientTypeId IngredientTypeId => ingredientTypeId;

        public IngredientSpawnData(IngredientTypeId ingredientTypeId, Vector3 position)
        {
            this.ingredientTypeId = ingredientTypeId;
            this.position = position;
        }
    }
}