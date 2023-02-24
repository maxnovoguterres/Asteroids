using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Asteroids.Scripts.Controller.Shared
{
    public abstract class Controller<T> : MonoBehaviour where T : MonoBehaviour
    {
        UnityAction awake;

        public Controller(UnityAction awake = null)
        {
            this.awake = awake;
        }

        private static T instance;
        public static T Instance
        {
            get
            {
                return instance;
            }
            set
            {
                instance = instance ?? value;
            }
        }

        protected virtual void Awake()
        {
            GetInstance();

            if (awake != null) awake.Invoke();
        }

        private void GetInstance()
        {
            if (instance == null)
            {
                instance = this as T;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
                return;
            }
        }
    }
}