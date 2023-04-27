using System;
using System.Collections.Generic;
using Infrastructure.Factories;
using Infrastructure.Services;
using Logic;
using StaticData;

namespace Infrastructure.States
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> states;
        private IExitableState activeState;

        public GameStateMachine(SceneLoader sceneLoader, LoadingCurtain curtain, ServiceLocator services)
        {
            states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, services),
                [typeof(LoadSceneState)] = new LoadSceneState(this, sceneLoader,
                    curtain, services.Single<IGameFactory>(),
                    services.Single<IStaticDataService>(),
                    services.Single<ICameraService>()),
                [typeof(GameLoopState)] = new GameLoopState(this),
            };
        }

        public void Enter<T>() where T : class, IState
        {
            T state = ChangeState<T>();
            state.Enter();
        }

        public void Enter<T, K>(K payload) where T : class, IPayloadedState<K>
        {
            T state = ChangeState<T>();
            state.Enter(payload);
        }

        private T ChangeState<T>() where T : class, IExitableState
        {
            activeState?.Exit();
            T state = GetState<T>();
            activeState = state;
            return state;
        }

        private T GetState<T>() where T : class, IExitableState
        {
            return states[typeof(T)] as T;
        }
    }
}