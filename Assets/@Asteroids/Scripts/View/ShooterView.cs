using System.Collections;
using System.Collections.Generic;
using Assets.Asteroids.Scripts.View;
using UnityEngine;
using Assets.Asteroids.Scripts.Model;
using Assets.Asteroids.Scripts.Controller;

namespace Assets.Asteroids.Scripts.View
{
    public class ShooterView : Shared.View
    {
        public Shooter Model;

        void Start()
        {
            if (!Model.isPlayer)
            {
                Model.target = FindObjectOfType<PlayerView>().transform;
                InvokeRepeating("Shoot", Model.fireRate, Model.fireRate);
            }
        }

        void FixedUpdate()
        {
            if (Model.isPlayer && Model.isShooting)
            {
                Model.isShooting = false;
                Shoot();
            }
        }

        private void Shoot()
        {
            ShooterController.Instance.Shoot(this);
        }
    }
}