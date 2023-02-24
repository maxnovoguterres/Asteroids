using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Asteroids.Scripts.Model
{
    [Serializable]
    public class Shooter
    {
        [HideInInspector] public Transform target;
        public GameObject projectilePrefab;
        public Transform projectileSpawner;
        public float fireRate = 1;
        public float projectileVelocity = 1;
        public bool isPlayer;
        [Header("Player")]
        public bool isShooting;
    }
}