using Infrastructure.Services;
using Logic;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private RectTransform crosshair;
        [SerializeField] private Transform itemHoldAnchor;
        private IRaycastService raycastService;
        private IInputService inputService;
        private PlayerObjectHoverer hoverer;
        private PlayerObjectAim aim;
        private PlayerObjectCatcher catcher;

        private void Update()
        {
            IHoverable hoveredObject = aim.GetAimedObject<IHoverable>();
            hoverer.TryToHoverObjects(hoveredObject);
        }

        public void Construct()
        {
            raycastService = ServiceLocator.Container.Single<IRaycastService>();
            inputService = ServiceLocator.Container.Single<IInputService>();
            aim = new PlayerObjectAim(crosshair, itemHoldAnchor, raycastService);
            hoverer = new PlayerObjectHoverer();
            catcher = new PlayerObjectCatcher(itemHoldAnchor);
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            inputService.OnCatchStarted += OnCatchStartedHandler;
            inputService.OnCatchStopped += OnCatchStoppedHandler;
            inputService.OnFireStarted += OnFireStartedHandler;
        }

        private void ThrowCatchedObject()
        {
            var cachedCatchedObject = catcher.CatchedObject;
            var direction = itemHoldAnchor.TransformDirection(Vector3.forward);
            catcher.ThrowCatchedObject(direction);
            if (cachedCatchedObject != null)
            {
                hoverer.ShowInteractableUIFor(cachedCatchedObject);
            }
        }

        private void ClickAimedObject()
        {
            IClickable clickableObject = aim.GetAimedObject<IClickable>();
            clickableObject?.Click();
        }

        private void CatchAimedObject()
        {
            ICatchable catchableObject = aim.GetAimedObject<ICatchable>();
            catcher.CatchAimedObject(catchableObject);
            hoverer.HideInteractableUIFor(catcher.CatchedObject);
        }

        private void DropAimedObject()
        {
            var cachedCatchedObject = catcher.CatchedObject;
            catcher.DropCatchedObject();
            if (cachedCatchedObject != null)
            {
                hoverer.ShowInteractableUIFor(cachedCatchedObject);
            }
        }

        private void OnFireStartedHandler()
        {
            ThrowCatchedObject();
            ClickAimedObject();
        }

        private void OnCatchStartedHandler()
        {
            CatchAimedObject();
        }

        private void OnCatchStoppedHandler()
        {
            DropAimedObject();
        }
    }
}