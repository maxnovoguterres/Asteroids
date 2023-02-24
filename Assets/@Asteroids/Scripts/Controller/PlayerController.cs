using System.Collections;
using Assets.Asteroids.Scripts.View;
using Assets.Asteroids.Scripts.Controller.Shared;
using Assets.Asteroids.Scripts.Model;
using UnityEngine;

namespace Assets.Asteroids.Scripts.Controller
{
    public class PlayerController : Controller<PlayerController>
    {
        [HideInInspector] public float score;
        public Transform player;
        
        public void Move(PlayerView View)
        {
            if (View.Model.verticalMovement < 0)
            {
                View.Model.verticalMovement = 0;
            }
            Rigidbody2D rb = View.GetRigidbody();
            rb.AddForce(-View.transform.right * View.Model.moveSpeed * View.Model.verticalMovement, ForceMode2D.Force);
        }

        public void Rotate(PlayerView View)
        {
            float rotationVelocity = View.Model.rotationSpeed * -View.Model.horizontalMovement * Time.deltaTime + View.transform.localEulerAngles.z;
            View.transform.localEulerAngles = Vector3.forward * rotationVelocity;
        }
        
        public void Animate(PlayerView View)
        {
            Animator animator = View.GetAnimator();
            animator.SetBool("IsMoving", View.Model.isMoving);
        }
        
        public void GetInputs(Player Model)
        {
            Model.horizontalMovement = Input.GetAxisRaw("Horizontal");
            Model.verticalMovement = Input.GetAxis("Vertical");
            Model.isMoving = Input.GetAxisRaw("Vertical") > 0;
            if (Input.GetKeyDown(KeyCode.Space) ||
                Input.GetKeyDown(KeyCode.Z) ||
                Input.GetKeyDown(KeyCode.J))
            {
                Model.shooterView.Model.isShooting = true;
            }
        }

        public void CheckInvencibility(PlayerView View)
        {
            if (View.Model.isInvencible)
            {
                if (View.Model.invencibilityCoroutine == null)
                {
                    View.Model.invencibilityCoroutine = StartCoroutine(InvencibilityCoroutine(View));
                }

                View.Model.invencibilityTimer += Time.deltaTime;
                if (View.Model.invencibilityTimer >= View.Model.invencibilityTime)
                {
                    View.Model.isInvencible = false;
                    View.Model.invencibilityTimer = 0;
                }
            }
        }

        private IEnumerator InvencibilityCoroutine (PlayerView View)
        {
            SpriteRenderer sr = View.GetComp<SpriteRenderer>();
            Color newColor = sr.color;

            while (View.Model.isInvencible)
            {
                newColor.a = 0;
                sr.color = newColor;

                yield return new WaitForSeconds(View.Model.blinkTime);

                newColor.a = 1;
                sr.color = newColor;

                yield return new WaitForSeconds(View.Model.blinkTime);
            }

            View.Model.invencibilityCoroutine = null;
        }
    }
}
