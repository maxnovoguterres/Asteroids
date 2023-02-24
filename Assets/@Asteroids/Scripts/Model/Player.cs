using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Asteroids.Scripts.View;
using TMPro;
using UnityEngine;

namespace Assets.Asteroids.Scripts.Model
{
    [Serializable]
    public class Player
    {
        public ShooterView shooterView;
        public HealthView healthView;
        [Header("Movement/Rotation")]
        public float moveSpeed = 4f;
        public float maxVelocity = 5f;
        public float rotationSpeed = 4f;
        [Header("Invencibility")]
        public float invencibilityTime;
        public float blinkTime;

        [HideInInspector] public float horizontalMovement;
        [HideInInspector] public float verticalMovement;
        [HideInInspector] public float invencibilityTimer;
        [HideInInspector] public bool isMoving;
        [HideInInspector] public bool isInvencible;
        public Coroutine invencibilityCoroutine;
    }
}