using System;
using UnityEngine;

namespace UIElements
{
    public class InteractableUIElement : MonoBehaviour
    {
        [SerializeField] private GameObject interactableUIHolder;

        private InteractableUIState currentState;

        public void SetState(InteractableUIState state)
        {
            currentState = state;
            switch (state)
            {
                case InteractableUIState.Disabled:
                    Disable();
                    break;

                case InteractableUIState.Active:
                    Enable();
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        private void Enable()
        {
            if (!interactableUIHolder.activeSelf)
            {
                interactableUIHolder.SetActive(true);
            }
        }

        private void Disable()
        {
            if (interactableUIHolder.activeSelf)
            {
                interactableUIHolder.SetActive(false);
            }
        }
    }
}