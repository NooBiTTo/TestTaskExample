using UnityEngine;

namespace UIElements
{
    public class InteractableUI : MonoBehaviour
    {
        [SerializeField] private InteractableUIElement root;
        [SerializeField] private InteractableUIElement outline;

        public InteractableUIElement Root => root;
        public InteractableUIElement Outline => outline;
    }
}