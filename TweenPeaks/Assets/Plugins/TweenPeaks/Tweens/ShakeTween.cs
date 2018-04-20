using UnityEngine;

namespace TweenPeaks.Tweens
{
    public class ShakeTween : TweenBase
    {
        private const int PhasesCountForSecond = 10;

        private Vector3 _startPosition;
        private float _shakeDistance;
        private Vector2 _direction = new Vector2(1f, 0f);
        private int _phasesCount;
        private bool _isLocal;

        public static ShakeTween Run(GameObject item, float shakeDistance, float duration)
        {
            ShakeTween tween = Create<ShakeTween>(item, duration);
            tween._startPosition = item.transform.position;
            tween._shakeDistance = shakeDistance;
            tween._phasesCount = Mathf.Max(10, (int) (PhasesCountForSecond*duration));
            return tween;
        }

        public static ShakeTween RunVertical(GameObject item, float shakeDistance, float duration)
        {
            ShakeTween tween = Run(item, shakeDistance, duration);
            tween._direction = new Vector2(0f, 1f);
            return tween;
        }

        public ShakeTween SetLocal()
        {
            _isLocal = true;
            _startPosition = transform.localPosition;
            return this;
        }

        public ShakeTween SetDirection(Vector2 direction)
        {
            _direction = direction.normalized;
            return this;
        }

        public ShakeTween SetPhasesCount(int phasesCount)
        {
            _phasesCount = phasesCount;
            return this;
        }

        protected override void UpdateValue(float time)
        {
            float distance = Mathf.Sin(time * _phasesCount * Mathf.PI) * _shakeDistance * (1f - time);
            Vector3 updatedPosition = _startPosition + (Vector3)_direction * distance;
            UpdatePosition(updatedPosition);
        }

        private void UpdatePosition(Vector3 updatedPosition)
        {
            if (_isLocal)
                transform.localPosition = updatedPosition;
            else
                transform.position = updatedPosition;
        }
    }
}
