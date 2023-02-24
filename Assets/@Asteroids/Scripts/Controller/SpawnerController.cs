using System.Collections;
using System.Collections.Generic;
using Assets.Asteroids.Scripts.Controller;
using Assets.Asteroids.Scripts.Helpers;
using UnityEngine;

namespace Assets.Asteroids.Scripts.Controller
{
    public class SpawnerController : Shared.Controller<SpawnerController>
    {
        public float minDistanceToPlayer;

        public void Spawn(GameObject prefab)
        {
            float minX = CameraController.Instance.GetCameraMinX();
            float maxX = CameraController.Instance.GetCameraMaxX();
            float minY = CameraController.Instance.GetCameraMinY();
            float maxY = CameraController.Instance.GetCameraMaxY();

            Vector2 spawnPosition = Vector2.zero;
            bool canSpawn = false;
            while (!canSpawn)
            {
                spawnPosition = new Vector2(RandomExtensions.GetRandomFloat(minX, maxX), RandomExtensions.GetRandomFloat(minY, maxY));
                float distanceToPlayer = Vector2.Distance(spawnPosition, PlayerController.Instance.player.position);
                if (distanceToPlayer > minDistanceToPlayer)
                {
                    canSpawn = true;
                }
            }
            Instantiate(prefab, spawnPosition, Quaternion.identity);
        }
    }
}