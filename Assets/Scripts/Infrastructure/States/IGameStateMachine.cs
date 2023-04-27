using Infrastructure.Services;

namespace Infrastructure.States
{
    public interface IGameStateMachine : IService
    {
        void Enter<T>() where T : class, IState;
        void Enter<T, K>(K payload) where T : class, IPayloadedState<K>;
    }
}