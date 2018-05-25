using UnityEngine;

namespace TweenPeaks.Tweens
{
	public class ShakeAngleTween : TweenBase
	{
		private const int PhasesCountForSecond = 10;

		private float _startAngle;
		private float _shakeAngleDistance;
		private int _phasesCount;

		public static ShakeAngleTween Run(GameObject item, float shakeAngleDistance, float duration)
		{
			ShakeAngleTween tween = Create<ShakeAngleTween>(item, duration);
			tween._shakeAngleDistance = shakeAngleDistance;
			tween._phasesCount = Mathf.Max(10, (int)(PhasesCountForSecond * duration));
			return tween;
		}

		protected override void OnStart()
		{
			_startAngle = transform.localEulerAngles.z;
		}

		public ShakeAngleTween SetPhasesCount(int phasesCount)
		{
			_phasesCount = phasesCount;
			return this;
		}

		protected override void UpdateValue(float time)
		{
			float angle = _startAngle + Mathf.Sin(time * _phasesCount * Mathf.PI) * _shakeAngleDistance * (1f - time);
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, angle);
		}
	}
}