using UnityEngine;

namespace Assets.@Asteroids.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Rank", menuName = "Scriptable Objects")]
    public class Ranking : ScriptableObject
    {
        public string Name;
        public int Time;
        public int Score;
    }
}
