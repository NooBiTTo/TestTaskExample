using System.Collections;
using UnityEngine;

namespace Logic
{
    public class LoadingCurtain : MonoBehaviour
    {
        private const int transparentAlpha = 1;
        private const int solidColorAlpha = 0;

        [SerializeField] private CanvasGroup curtain;

        [Space(10f)] [Header("Settings")] [SerializeField]
        private float changingAlphaStep = 0.03f;

        [SerializeField] private float stepDuration = 0.03f;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            curtain.alpha = transparentAlpha;
        }

        public void Hide() => StartCoroutine(DoFadeIn());

        private IEnumerator DoFadeIn()
        {
            while (curtain.alpha > solidColorAlpha)
            {
                curtain.alpha -= changingAlphaStep;
                yield return new WaitForSeconds(stepDuration);
            }

            gameObject.SetActive(false);
        }
    }
}