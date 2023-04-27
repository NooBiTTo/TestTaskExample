using System;
using System.Collections.Generic;
using UnityEngine;

namespace StaticData
{
    [Serializable]
    public class ReceiptData
    {
        [SerializeField] private List<IngredientTypeId> ingredients;
        [SerializeField] private IngredientTypeId result;

        public List<IngredientTypeId> Ingredients => ingredients;
        public IngredientTypeId Result => result;
    }
}