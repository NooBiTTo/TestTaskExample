using System;

namespace Infrastructure.Services
{
    public interface IInputService : IService
    {
        event Action OnFireStarted;
        event Action OnFireStopped;
        event Action OnCatchStarted;
        event Action OnCatchStopped;
        void Enable();
        void Disable();
    }
}