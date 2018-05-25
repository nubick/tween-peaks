using UnityEngine;

namespace Assets.Scripts.Demo.TweenActions
{
    public abstract class TweenAction
    {
        public abstract void Run(GameObject target, TweenActionSettings settings);

		public MonoBehaviour CoroutinesHoster { get; set; }

        protected Vector2 GetRandomScreenPoint()
        {
            return Random.insideUnitCircle * Screen.height * 0.75f;
        }
    }
}
