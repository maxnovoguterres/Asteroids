using System.Collections.Generic;
using System.Linq;
using Assets.Asteroids.Scripts.View;
using Assets.Asteroids.Scripts.Controller.Shared;
using Assets.Asteroids.Scripts.Helpers;
using UnityEngine;

namespace Assets.Asteroids.Scripts.Controller
{
    public class RestartController : Controller<RestartController>
    {
        public void ResetLevel()
        {
            UIController.Instance.ResetUI();
            PlayerView playerView = PlayerController.Instance.player.GetComponent<PlayerView>();
            playerView.transform.position = Vector3.zero;
            playerView.transform.eulerAngles = new Vector3(0, 0, 180);
            Rigidbody2D playerRb = playerView.GetRigidbody();
            playerRb.velocity = Vector2.zero;
            playerRb.angularVelocity = 0;
            HealthController.Instance.ResetHealth(playerView.Model.healthView);
            playerView.gameObject.SetActive(true);

            Globals.FindObjectsOfTypeAll<DestroyObjectView>().ForEach(x => x.Model.canDestroy = true);
            
            LevelController.Instance.StartNewLevel(0);
        }
    }
}