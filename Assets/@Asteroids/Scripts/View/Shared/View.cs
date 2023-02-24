using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Asteroids.Scripts.View.Shared
{
    public class View : MonoBehaviour
    {
        public Dictionary<string, object> Components = new Dictionary<string, object>();

        public T GetComp<T>()
        {
            string name = typeof(T).Name;
            if (!Components.ContainsKey(name))
            {
                Components[name] = GetComponent<T>();
            }

            return (T)Components[name];
        }

        public static explicit operator GameObject(View b) => b.gameObject;
    }
}