using System.Collections;
using Assets.Asteroids.Scripts.Controller;
using Assets.Asteroids.Scripts.Enums;
using Assets.Asteroids.Scripts.Model;
using UnityEngine;

namespace Assets.Asteroids.Scripts.View
{
    public class PlayerView : Shared.View
    {
        public Player Model;

        #region Getters
        public SpriteRenderer GetSpriteRenderer()
        {
            return GetComp<SpriteRenderer>();
        }

        public Rigidbody2D GetRigidbody ()
        {
            return GetComp<Rigidbody2D>();
        }

        public Animator GetAnimator ()
        {
            return GetComp<Animator>();
        }
        #endregion
        
        private void Update()
        {
            PlayerController.Instance.GetInputs(Model);
            PlayerController.Instance.Rotate(this);
            PlayerController.Instance.Animate(this);
            PlayerController.Instance.CheckInvencibility(this);
        }

        private void FixedUpdate()
        {
            PlayerController.Instance.Move(this);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("KillPlayer"))
            {
                if (!Model.isInvencible)
                {
                    HealthController.Instance.GetDamage(this, 1);
                    Destroy(other.gameObject);
                }
            }
        }
    }
}
