using System.Collections;
using System.Collections.Generic;
using Assets.Asteroids.Scripts.Controller;
using Assets.Asteroids.Scripts.View;
using UnityEngine;

namespace Assets.Asteroids.Scripts.Controller
{
    public class ShooterController : Shared.Controller<ShooterController>
    {
        public void Shoot(ShooterView View)
        {
            GameObject projectile = Instantiate(View.Model.projectilePrefab, View.Model.projectileSpawner.position, Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (View.Model.isPlayer)
            {
                rb.AddForce(-View.transform.right * View.Model.projectileVelocity, ForceMode2D.Force);
            }
            else
            {
                Vector2 direction = (PlayerController.Instance.player.position - View.transform.position).normalized;
                rb.AddForce(direction * View.Model.projectileVelocity);
            }
        }
    }
}