using Logic;
using UIElements;
using UnityEngine;

namespace Player
{
    public class PlayerObjectHoverer
    {
        private IHoverable prevHoveredObject;

        public void HideInteractableUIFor(ICatchable catchableObject)
        {
            if (catchableObject is MonoBehaviour catchableGameObject)
            {
                if (catchableGameObject.TryGetComponent(out IInteractable interactable))
                {
                    interactable.HideInteractableUI();
                }
            }
        }

        public void ShowInteractableUIFor(ICatchable catchableObject)
        {
            if (catchableObject is MonoBehaviour catchableGameObject)
            {
                if (catchableGameObject.TryGetComponent(out IInteractable interactable))
                {
                    interactable.ShowInteractableUI();
                }
            }
        }

        public void TryToHoverObjects(IHoverable hoveredObject)
        {
            if (hoveredObject != prevHoveredObject)
            {
                hoveredObject?.Hover();
                prevHoveredObject?.Unhover();
                prevHoveredObject = hoveredObject;
            }
        }
    }
}