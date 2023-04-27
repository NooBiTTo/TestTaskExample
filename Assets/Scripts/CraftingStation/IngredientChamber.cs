using System;
using System.Collections.Generic;
using Ingredients;
using UnityEngine;

namespace CraftingStation
{
    public class IngredientChamber : MonoBehaviour
    {
        public event Action<List<Ingredient>> OnUpdateIngredients;
        private List<Ingredient> ingredientsInChamber = new List<Ingredient>();
        public List<Ingredient> IngredientsInChamber => ingredientsInChamber;

        private void OnTriggerEnter(Collider other)
        {
            ReliableOnTriggerExit.NotifyTriggerEnter(other, gameObject, OnTriggerExit);
            if (other.TryGetComponent(out Ingredient ingredient))
            {
                ingredientsInChamber.Add(ingredient);
                OnUpdateIngredients?.Invoke(ingredientsInChamber);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            ReliableOnTriggerExit.NotifyTriggerExit(other, gameObject);
            if (other.TryGetComponent(out Ingredient ingredient))
            {
                ingredientsInChamber.Remove(ingredient);
                OnUpdateIngredients?.Invoke(ingredientsInChamber);
            }
        }

        public void DeleteObjectsInChamber()
        {
            foreach (var ingredient in ingredientsInChamber)
            {
                Destroy(ingredient.gameObject);
            }

            ingredientsInChamber.Clear();
            OnUpdateIngredients?.Invoke(ingredientsInChamber);
        }
    }
}