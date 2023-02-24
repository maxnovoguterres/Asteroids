using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Asteroids.Scripts.Controller
{
    public class LevelController : Shared.Controller<LevelController>
    {
        public GameObject rockPrefab;
        public GameObject enemy01Prefab;
        public int secondsToWaitForNewLevel;
        public int initialNumberOfRocksToSpawn;
        public int numberOfRocksToSpawn;
        public int numberOfEnemiesToSpawn;
        [HideInInspector] public int enemiesLeftToKill;

        void Start()
        {
            StartNewLevel(0);
        }

        public void StartNewLevel(int seconds)
        {
            numberOfRocksToSpawn++;
            StartCoroutine(StartNewLevelCoroutine(seconds));
        }

        public bool IsLevelCleared()
        {
            return enemiesLeftToKill <= 0;
        }

        private IEnumerator StartNewLevelCoroutine(int seconds)
        {
            yield return new WaitForSeconds(seconds);

            for (int i = 0; i < numberOfRocksToSpawn; i++)
            {
                enemiesLeftToKill += 7;
                SpawnerController.Instance.Spawn(rockPrefab);
            }

            for (int j = 0; j < numberOfEnemiesToSpawn; j++)
            {
                enemiesLeftToKill++;
                SpawnerController.Instance.Spawn(enemy01Prefab);
            }
        }
    }
}