using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Asteroids.Scripts.Model
{
    [Serializable]
    public class DestroyObject
    {
        public bool isDestroyedByTime;
        public float timeToDestroy;
        [HideInInspector] public bool canDestroy;
    }
}