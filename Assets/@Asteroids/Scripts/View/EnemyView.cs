using System.Collections;
using System.Collections.Generic;
using Assets.Asteroids.Scripts.View;
using UnityEngine;
using Assets.Asteroids.Scripts.Model;
using Assets.Asteroids.Scripts.Controller;

namespace Assets.Asteroids.Scripts.View
{
    public class EnemyView : Shared.View
    {
        public Enemy Model;

        #region Getters
        public Rigidbody2D GetRigidbody ()
        {
            return GetComp<Rigidbody2D>();
        }
        #endregion

        void Start()
        {
            EnemyController.Instance.SetSprites(this);
            EnemyController.Instance.AddForceAndTorque(this);
        }

        private void OnTriggerEnter2D (Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerView player = other.GetComponent<PlayerView>();
                if (!player.Model.isInvencible)
                {
                    EnemyController.Instance.Damage(this, player);
                }
            }
            else if (other.CompareTag("KillEnemies"))
            {
                EnemyController.Instance.Damage(this, collidedObjToDestroy: other.gameObject);
            }
        }
    }
}