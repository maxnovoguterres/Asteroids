using System.Collections;
using System.Collections.Generic;
using Assets.Asteroids.Scripts.View;
using UnityEngine;

namespace Assets.Asteroids.Scripts.Controller
{
    public class HealthController : Shared.Controller<HealthController>
    {
        public void GetDamage(PlayerView playerView, int damage)
        {
            if (playerView.Model.healthView.Model.currentHealth > 0)
            {
                UIController.Instance.UpdateLifes(playerView.Model.healthView.Model.currentHealth);

                playerView.Model.healthView.Model.currentHealth -= damage;
                if (playerView.Model.healthView.Model.currentHealth <= 0)
                {
                    playerView.Model.healthView.Model.currentHealth = 0;
                    UIController.Instance.UpdateHighScore();
                    UIController.Instance.SetGameOverVisibility(true);
                    playerView.gameObject.SetActive(false);
                }
                else
                {
                    playerView.Model.isInvencible = true;
                }
            }
        }

        public void ResetHealth(HealthView View)
        {
            View.Model.currentHealth = View.Model.maxHealth;
        }
    }
}