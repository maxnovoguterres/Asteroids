using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Asteroids.Scripts.Model
{
    [Serializable]
    public class Health
    {
        [HideInInspector] public int currentHealth;
        public int maxHealth;
    }
}