using Logic;
using UnityEngine;

namespace UIElements
{
    public class InteractableUIController : MonoBehaviour, IHoverable, IInteractable
    {
        private const float maxDistanceForShowInteractableUI = 10f;
        private InteractableUI interactableUI;
        private Transform playerTransform;
        private bool isInteractableActiveState = true;

        private void Update()
        {
            if (IsCloseForShowInteractableUI() && isInteractableActiveState)
            {
                interactableUI.Root.SetState(InteractableUIState.Active);
            }
            else
            {
                interactableUI.Root.SetState(InteractableUIState.Disabled);
            }
        }

        public void Construct(InteractableUI interactableUI, Transform player)
        {
            this.interactableUI = interactableUI;
            playerTransform = player;
            this.interactableUI.Outline.SetState(InteractableUIState.Disabled);
            this.interactableUI.Root.SetState(InteractableUIState.Disabled);
        }

        public void Hover()
        {
            interactableUI.Outline.SetState(InteractableUIState.Active);
        }

        public void Unhover()
        {
            interactableUI.Outline.SetState(InteractableUIState.Disabled);
        }

        public void ShowInteractableUI()
        {
            isInteractableActiveState = true;
        }

        public void HideInteractableUI()
        {
            isInteractableActiveState = false;
        }

        private bool IsCloseForShowInteractableUI()
        {
            return Vector3.Distance(playerTransform.position, transform.position) <= maxDistanceForShowInteractableUI;
        }
    }
}