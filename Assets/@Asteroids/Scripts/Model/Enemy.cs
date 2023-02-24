using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Asteroids.Scripts.Enums;
using UnityEngine;

namespace Assets.Asteroids.Scripts.Model
{
    [Serializable]
    public class Enemy
    {
        public int scorePoints;
        public float maxTorque = 100;
        public float maxForce = 100;
        public float enemiesToSpawn = 2;
        public EnemyType enemyType;
    }
}