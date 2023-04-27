using Infrastructure.Factories;
using Infrastructure.Services;
using Logic;
using Player;
using StaticData;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.States
{
    public class LoadSceneState : IPayloadedState<string>
    {
        private readonly GameStateMachine stateMachine;
        private readonly SceneLoader sceneLoader;

        private readonly LoadingCurtain curtain;
        private readonly IGameFactory gameFactory;
        private readonly IStaticDataService staticData;
        private readonly ICameraService cameraService;

        public LoadSceneState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain,
            IGameFactory gameFactory, IStaticDataService staticData, ICameraService cameraService)
        {
            this.stateMachine = stateMachine;
            this.sceneLoader = sceneLoader;
            this.curtain = curtain;
            this.gameFactory = gameFactory;
            this.staticData = staticData;
            this.cameraService = cameraService;
        }

        public void Enter(string sceneName)
        {
            curtain.Show();
            sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            curtain.Hide();
        }

        private void OnLoaded()
        {
            InitGameWorld();
            stateMachine.Enter<GameLoopState>();
        }

        private void InitGameWorld()
        {
            LevelStaticData levelData = LevelStaticData();
            var playerCamera = InitPlayerCamera();
            var playerGameObject = InitPlayer(levelData);
            InitCraftStations(levelData);
            InitIngredients(levelData);
            CameraFollow(playerGameObject);
        }

        private LevelStaticData LevelStaticData()
        {
            string sceneKey = SceneManager.GetActiveScene().name;
            LevelStaticData levelData = staticData.ForLevel(sceneKey);
            return levelData;
        }

        private GameObject InitPlayerCamera()
        {
            var cameraGameObject = gameFactory.CreatePlayerCamera();
            cameraService.SetPlayerCamera(cameraGameObject.GetComponent<Camera>());
            return cameraGameObject;
        }

        private GameObject InitPlayer(LevelStaticData levelData)
        {
            var playerGameObject = gameFactory.CreatePlayer(levelData.InitialPlayerPosition);
            PlayerController playerController = playerGameObject.GetComponent<PlayerController>();
            playerController.Construct();
            return playerGameObject;
        }

        private void InitCraftStations(LevelStaticData levelData)
        {
            foreach (CraftStationsSpawnData craftStation in levelData.CraftStationSpawnDatas)
            {
                gameFactory.CreateCraftStation(craftStation.Position);
            }
        }

        private void InitIngredients(LevelStaticData levelData)
        {
            foreach (IngredientSpawnData ingredient in levelData.IngredientSpawnDatas)
            {
                gameFactory.CreateIngredient(ingredient.IngredientTypeId, ingredient.Position);
            }
        }

        private void CameraFollow(GameObject playerGameObject)
        {
            var virtualCameraGameObject = gameFactory.CreateVirtualCamera();
            if (playerGameObject.TryGetComponent(out PlayerCameraHandler cameraHandler))
            {
                cameraService.SetCameraFollowTo(cameraHandler.CameraRoot, virtualCameraGameObject);
            }
        }
    }
}