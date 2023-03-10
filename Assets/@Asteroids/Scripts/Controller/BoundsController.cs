using System.Collections;
using System.Collections.Generic;
using Assets.Asteroids.Scripts.Controller;
using Assets.Asteroids.Scripts.View;
using UnityEngine;

namespace Assets.Asteroids.Scripts.Controller
{
    public class BoundsController : Shared.Controller<BoundsController>
    {
        public void SetBounds(BoundsView View)
        {
            SpriteRenderer sr = View.GetSpriteRenderer();
            View.Model.maxRightBounds = CameraController.Instance.GetCameraMaxX() + sr.bounds.extents.x;
            View.Model.maxLeftBounds = CameraController.Instance.GetCameraMinX() - sr.bounds.extents.x;
            View.Model.maxTopBounds = CameraController.Instance.GetCameraMaxY() + sr.bounds.extents.y;
            View.Model.maxBottomBounds = CameraController.Instance.GetCameraMinY() - sr.bounds.extents.y;
        }

        public void CheckBounds (BoundsView View)
        {
            if (CameraController.Instance.HasWidthAndHeightChanged())
            {
                CameraController.Instance.UpdateWidthAndHeight();
                SetBounds(View);
            }

            Vector2 newPosition = View.transform.position;
            if (View.transform.position.y > View.Model.maxTopBounds)
            {
                newPosition.y = View.Model.maxBottomBounds;
            }
            else if (View.transform.position.y < View.Model.maxBottomBounds)
            {
                newPosition.y = View.Model.maxTopBounds;
            }
            if (View.transform.position.x > View.Model.maxRightBounds)
            {
                newPosition.x = View.Model.maxLeftBounds;
            }
            else if (View.transform.position.x < View.Model.maxLeftBounds)
            {
                newPosition.x = View.Model.maxRightBounds;
            }
            View.transform.position = newPosition;
        }
    }
}