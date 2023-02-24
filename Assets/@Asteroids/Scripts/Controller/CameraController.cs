using Assets.Asteroids.Scripts.View;
using Assets.Asteroids.Scripts.Controller.Shared;
using UnityEngine;

namespace Assets.Asteroids.Scripts.Controller
{
    public class CameraController : Controller<CameraController>
    {
        [HideInInspector] public int currentWidth;
        [HideInInspector] public int currentHeight;

        public Vector3 minPos = new Vector3(0, 0, -10f);
        public Vector3 maxPos = new Vector3(0, 0, -10f);

        protected override void Awake()
        {
            if (Instance != null)
            {
                Instance.minPos = minPos;
                Instance.maxPos = maxPos;
            }
            base.Awake();
        }

        void Start()
        {
            UpdateWidthAndHeight();
        }

        public void UpdateWidthAndHeight()
        {
            currentWidth = Camera.main.pixelWidth;
            currentHeight = Camera.main.pixelHeight;
        }

        public bool HasWidthAndHeightChanged()
        {
            return currentWidth != Camera.main.pixelWidth || currentHeight != Camera.main.pixelHeight;
        }

        public float GetCameraMinX()
        {
            float x = minPos.x;
            x -= Camera.main.orthographicSize * Camera.main.aspect;
            return x;
        }

        public float GetCameraMaxX()
        {
            float x = maxPos.x;
            x += Camera.main.orthographicSize * Camera.main.aspect;
            return x;
        }

        public float GetCameraMinY ()
        {
            float y = minPos.y;
            y -= Camera.main.orthographicSize;
            return y;
        }

        public float GetCameraMaxY ()
        {
            float y = maxPos.y;
            y += Camera.main.orthographicSize;
            return y;
        }
    }
}