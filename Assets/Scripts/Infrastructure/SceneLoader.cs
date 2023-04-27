using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            this.coroutineRunner = coroutineRunner;
        }

        public void Load(string name, Action onSceneLoaded = null)
        {
            coroutineRunner.StartCoroutine(LoadScene(name, onSceneLoaded));
        }

        private IEnumerator LoadScene(string name, Action onSceneLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == name)
            {
                onSceneLoaded?.Invoke();
                yield break;
            }

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);
            while (!waitNextScene.isDone)
            {
                yield return null;
            }

            onSceneLoaded?.Invoke();
        }
    }
}