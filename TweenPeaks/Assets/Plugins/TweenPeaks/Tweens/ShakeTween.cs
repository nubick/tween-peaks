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
			tween._shakeDistance = shakeDistance;
			tween._phasesCount = Mathf.Max(10, (int)(PhasesCountForSecond * duration));
			return tween;
		}

		protected override void OnStart()
		{
			_startPosition = _isLocal ? transform.localPosition : transform.position;
		}

		public static ShakeTween Run(GameObject item, float shakeDistance, Vector2 direction, float duration)
		{
			ShakeTween shakeTween = Run(item, shakeDistance, duration);
			shakeTween._direction = direction;
			return shakeTween;
		}

		public static ShakeTween RunLeft(GameObject item, float shakeDistance, float duration)
		{
			return Run(item, shakeDistance, new Vector2(-1f, 0f), duration);
		}

		public static ShakeTween RunRight(GameObject item, float shakeDistance, float duration)
		{
			return Run(item, shakeDistance, new Vector2(1f, 0f), duration);
		}

		public static ShakeTween RunUp(GameObject item, float shakeDistance, float duration)
		{
			return Run(item, shakeDistance, new Vector2(0f, 1f), duration);
		}

		public static ShakeTween RunDown(GameObject item, float shakeDistance, float duration)
		{
			return Run(item, shakeDistance, new Vector2(0f, -1f), duration);
		}

		public ShakeTween SetLocal()
		{
			_isLocal = true;
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