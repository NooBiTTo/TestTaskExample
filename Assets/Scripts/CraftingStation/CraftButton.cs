using System;
using System.Collections;
using Logic;
using UnityEngine;

namespace CraftingStation
{
    public class CraftButton : MonoBehaviour, IHoverable, IClickable
    {
        private const string colorPropertyName = "_BaseColor";
        public event Action OnButtonClick;
        [SerializeField] private Color hoverColor;
        [SerializeField] private Color defaultColor;
        [SerializeField] private Color pressedColor;
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private float pressedAnimationDuration = 0.2f;
        private MaterialPropertyBlock block;
        private CraftButtonState state;
        private CraftButtonState cachedState;
        private Coroutine pressedAnimation = null;

        public void Init()
        {
            block ??= new MaterialPropertyBlock();
            SetButtonState(CraftButtonState.Default);
        }

        public void Hover()
        {
            SetButtonState(CraftButtonState.Hovered);
            cachedState = CraftButtonState.Hovered;
        }

        public void Unhover()
        {
            SetButtonState(CraftButtonState.Default);
            cachedState = CraftButtonState.Default;
        }

        public void Click()
        {
            SetButtonState(CraftButtonState.Pressed);
        }

        private void SetButtonState(CraftButtonState state)
        {
            if (this.state == CraftButtonState.Pressed)
            {
                return;
            }

            this.state = state;
            switch (state)
            {
                case CraftButtonState.Default:
                    SetButtonColor(defaultColor);
                    break;
                case CraftButtonState.Hovered:
                    SetButtonColor(hoverColor);
                    break;
                case CraftButtonState.Pressed:
                    StartPressedAnimation();
                    OnButtonClick?.Invoke();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        private void SetButtonColor(Color color)
        {
            block.SetColor(colorPropertyName, color);
            meshRenderer.SetPropertyBlock(block);
        }

        private void StartPressedAnimation()
        {
            if (pressedAnimation == null)
            {
                pressedAnimation = StartCoroutine(PressedButtonCoroutine());
            }
        }

        private IEnumerator PressedButtonCoroutine()
        {
            SetButtonColor(pressedColor);
            yield return new WaitForSeconds(pressedAnimationDuration);
            state = cachedState;
            SetButtonState(state);
            pressedAnimation = null;
        }
    }
}