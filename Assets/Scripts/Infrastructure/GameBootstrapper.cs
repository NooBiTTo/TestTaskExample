using Infrastructure.States;
using Logic;
using UnityEngine;

namespace Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private LoadingCurtain curtainPrefab;
        private Game game;

        private void Awake()
        {
            game = new Game(this, Instantiate(curtainPrefab));
            game.StateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}