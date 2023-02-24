using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Asteroids.Scripts.Model;
using Assets.Asteroids.Scripts.Controller;

namespace Assets.Asteroids.Scripts.View
{
    public class HealthView : Shared.View
    {
        public Health Model;

        void Start()
        {
            Model.currentHealth = Model.maxHealth;
        }
    }
}