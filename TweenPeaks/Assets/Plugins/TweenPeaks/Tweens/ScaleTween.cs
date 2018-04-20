using UnityEngine;

namespace TweenPeaks.Tweens
{
    public class ScaleTween : TweenBase
    {
        private Vector3 _startScale;
        private Vector3 _targetScale;

        public static ScaleTween Run(GameObject item, Vector3 scale, float duration)
        {
            ScaleTween tween = Create<ScaleTween>(item, duration);
            tween._targetScale = scale;
            return tween;
        }

        protected override void OnStart()
        {
            _startScale = transform.localScale;
        }

        protected override void UpdateValue(float time)
        {
            transform.localScale = new Vector3(
                EaseFunc(_startScale.x, _targetScale.x, time),
                EaseFunc(_startScale.y, _targetScale.y, time),
                EaseFunc(_startScale.z, _targetScale.z, time));
        }
    }
}
