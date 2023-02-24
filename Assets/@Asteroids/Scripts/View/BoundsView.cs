using System.Collections;
using System.Collections.Generic;
using Assets.Asteroids.Scripts.Controller;
using UnityEngine;
using Bounds = Assets.Asteroids.Scripts.Model.Bounds;

namespace Assets.Asteroids.Scripts.View
{
    public class BoundsView : Shared.View
    {
        public Bounds Model;

        #region Getters
        public SpriteRenderer GetSpriteRenderer ()
        {
            return GetComp<SpriteRenderer>();
        }
        #endregion

        private void Start ()
        {
            BoundsController.Instance.SetBounds(this);
        }

        private void LateUpdate()
        {
            BoundsController.Instance.CheckBounds(this);
        }
    }
}