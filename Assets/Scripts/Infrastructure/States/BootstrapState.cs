using Infrastructure.AssetManagement;
using Infrastructure.Factories;
using Infrastructure.Services;
using StaticData;
using UnityEngine;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string initialSceneName = "InitialScene";
        private const string playgroundSceneName = "Playground";
        private readonly GameStateMachine stateMachine;
        private readonly SceneLoader sceneLoader;
        private readonly ServiceLocator services;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, ServiceLocator services)
        {
            this.stateMachine = stateMachine;
            this.sceneLoader = sceneLoader;
            this.services = services;
            RegisterServices();
        }

        public void Enter()
        {
            sceneLoader.Load(initialSceneName, onSceneLoaded: EnterLoadLevel);
        }

        public void Exit()
        {
        }

        private void EnterLoadLevel()
        {
            stateMachine.Enter<LoadSceneState, string>(playgroundSceneName);
        }

        private void RegisterServices()
        {
            RegisterStaticData();
            services.RegisterSingle<IGameStateMachine>(stateMachine);
            services.RegisterSingle<IAssetProvider>(new AssetProvider());
            services.RegisterSingle<ICameraService>(new CameraService());
            services.RegisterSingle<IInputService>(new InputService());

            services.RegisterSingle<IGameFactory>
            (new GameFactory(services.Single<IAssetProvider>(),
                services.Single<IStaticDataService>(),
                services.Single<ICameraService>()));
            services.RegisterSingle<IRaycastService>(new RaycastService(
                services.Single<ICameraService>()));
            Debug.Log("<color=cyan>All Services Registered</color>");
        }

        private void RegisterStaticData()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.LoadData();
            services.RegisterSingle<IStaticDataService>(staticData);
        }
    }
}