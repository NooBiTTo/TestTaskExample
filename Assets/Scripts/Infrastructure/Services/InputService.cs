using System;

namespace Infrastructure.Services
{
    public class InputService : IInputService
    {
        public event Action OnFireStarted;
        public event Action OnFireStopped;
        public event Action OnCatchStarted;
        public event Action OnCatchStopped;
        private StarterAssets inputs;

        public InputService()
        {
            inputs = new StarterAssets();
            Enable();
            SubscribeButtonsEvents();
        }

        public void Enable()
        {
            inputs.Enable();
        }

        public void Disable()
        {
            inputs.Disable();
        }

        private void SubscribeButtonsEvents()
        {
            SubscribeFireEvents();
            SubscribeCatchEvents();
        }

        private void SubscribeFireEvents()
        {
            inputs.Player.Fire.started += context => { OnFireStarted?.Invoke(); };
            inputs.Player.Fire.canceled += context => { OnFireStopped?.Invoke(); };
        }

        private void SubscribeCatchEvents()
        {
            inputs.Player.Catch.started += context => { OnCatchStarted?.Invoke(); };
            inputs.Player.Catch.canceled += context => { OnCatchStopped?.Invoke(); };
        }
    }
}