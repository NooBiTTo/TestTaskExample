namespace Infrastructure.States
{
    public interface IState : IExitableState
    {
        void Enter();
    }

    public interface IExitableState
    {
        void Exit();
    }

    public interface IPayloadedState<T> : IExitableState
    {
        void Enter(T payload);
    }
}