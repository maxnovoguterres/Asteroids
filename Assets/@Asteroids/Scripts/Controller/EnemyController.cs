using System.Collections;
using System.Collections.Generic;
using Assets.Asteroids.Scripts.Helpers;
using Assets.Asteroids.Scripts.View;
using Assets.Asteroids.Scripts.Enums;
using UnityEngine;

namespace Assets.Asteroids.Scripts.Controller
{
    public class EnemyController : Shared.Controller<EnemyController>
    {
        public List<Sprite> bigRockSprites;
        public List<Sprite> rockSprites;
        public List<Sprite> smallRockSprites;

        public void SetSprites(EnemyView View)
        {
            if (View.Model.enemyType == EnemyType.BigRock)
            {
                int randomSpriteIndex = RandomExtensions.GetRandomInt(0, rockSprites.Count);
                foreach (SpriteRenderer sr in View.GetComponentsInChildren<SpriteRenderer>(true))
                {
                    switch (sr.GetComponent<EnemyView>().Model.enemyType)
                    {
                        case EnemyType.BigRock:
                            sr.sprite = bigRockSprites[randomSpriteIndex];
                            break;
                        case EnemyType.Rock:
                            sr.sprite = rockSprites[randomSpriteIndex];
                            break;
                        case EnemyType.SmallRock:
                            sr.sprite = smallRockSprites[randomSpriteIndex];
                            break;
                    }
                }
            }
        }

        public void AddForceAndTorque(EnemyView View)
        {
            Rigidbody2D rb = View.GetRigidbody();
            Vector2 force = new Vector2(RandomExtensions.GetRandomFloat(1, View.Model.maxForce), RandomExtensions.GetRandomFloat(1, View.Model.maxForce));
            float torque = RandomExtensions.GetRandomFloat(1, View.Model.maxTorque);
            rb.AddForce(force, ForceMode2D.Force);
            rb.AddTorque(torque, ForceMode2D.Force);
        }

        public void Damage(EnemyView View, PlayerView player = null, GameObject collidedObjToDestroy = null)
        {
            UIController.Instance.UpdateScore(View.Model.scorePoints);
            LevelController.Instance.enemiesLeftToKill--;
            if (LevelController.Instance.IsLevelCleared())
            {
                LevelController.Instance.StartNewLevel(LevelController.Instance.secondsToWaitForNewLevel);
            }

            if (player != null)
            {
                HealthController.Instance.GetDamage(player, 1);
            }

            List<Transform> transforms = new List<Transform>();
            for (int i = 0; i < View.transform.childCount; i++)
            {
                View.transform.GetChild(i).gameObject.SetActive(true);
                transforms.Add(View.transform.GetChild(i));
            }

            foreach (Transform transform in transforms)
            {
                transform.parent = null;
            }
            Destroy(View.gameObject);
            if (collidedObjToDestroy != null)
            {
                Destroy(collidedObjToDestroy);
            }
        }
    }
}