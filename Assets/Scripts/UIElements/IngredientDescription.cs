using System.Collections.Generic;
using Infrastructure.Factories;
using TMPro;
using UnityEngine;

namespace UIElements
{
    public class IngredientDescription : MonoBehaviour
    {
        [SerializeField] private Transform listRoot;
        private List<TextMeshPro> ingredientDescriptionList = new List<TextMeshPro>();
        private IGameFactory gameFactory;

        public void Construct(IGameFactory gameFactory)
        {
            this.gameFactory = gameFactory;
        }

        public void DeleteDescription()
        {
            foreach (var ingredientDescription in ingredientDescriptionList)
            {
                Destroy(ingredientDescription.gameObject);
            }

            ingredientDescriptionList.Clear();
        }

        public void AddDescription(string content)
        {
            var ingredientDescriptionGameObject = gameFactory.CreateIngredientDescription();
            ingredientDescriptionGameObject.transform.parent = listRoot;
            ingredientDescriptionGameObject.transform.localPosition = Vector3.zero;
            ingredientDescriptionGameObject.transform.localScale = Vector3.one;
            if (ingredientDescriptionGameObject.TryGetComponent(out TextMeshPro ingredientDescription))
            {
                ingredientDescriptionList.Add(ingredientDescription);
                ingredientDescription.text = content;
            }
        }
    }
}