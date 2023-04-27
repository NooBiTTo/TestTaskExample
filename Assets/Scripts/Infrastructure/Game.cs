using Infrastructure.Services;
using Infrastructure.States;
using Logic;

namespace Infrastructure
{
    public class Game
    {
        private readonly GameStateMachine stateMachine;
        public GameStateMachine StateMachine => stateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain)
        {
            stateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain, ServiceLocator.Container);
        }
    }
}