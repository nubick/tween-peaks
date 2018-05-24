using UnityEngine;

namespace TweenPeaks.Tweens
{
	public class ScaleTween : TweenBase
	{
		private Vector3 _startScale;
		private Vector3 _targetScale;
		private bool[] _scalingCoordinates;

		public static ScaleTween Run(GameObject item, Vector3 scale, float duration)
		{
			ScaleTween tween = Create<ScaleTween>(item, duration);
			tween._targetScale = scale;
			tween._scalingCoordinates = new bool[] { true, true, true };
			return tween;
		}

		public static ScaleTween Run(GameObject item, float scale, float duration)
		{
			return Run(item, Vector3.one * scale, duration);
		}

		public static ScaleTween RunX(GameObject item, float scaleX, float duration)
		{
			ScaleTween tween = Create<ScaleTween>(item, duration);
			tween._targetScale = new Vector3(scaleX, 0f, 0f);
			tween._scalingCoordinates = new bool[] { true, false, false };
			return tween;
		}

		public static ScaleTween RunY(GameObject item, float scaleY, float duration)
		{
			ScaleTween tween = Create<ScaleTween>(item, duration);
			tween._targetScale = new Vector3(0f, scaleY, 0f);
			tween._scalingCoordinates = new bool[] { false, true, false };
			return tween;
		}

		public static ScaleTween RunZ(GameObject item, float scaleZ, float duration)
		{
			ScaleTween tween = Create<ScaleTween>(item, duration);
			tween._targetScale = new Vector3(0f, 0f, scaleZ);
			tween._scalingCoordinates = new bool[] { false, false, true };
			return tween;
		}

		protected override void OnStart()
		{
			_startScale = transform.localScale;
			_targetScale = new Vector3(
				_scalingCoordinates[0] ? _targetScale.x : _startScale.x,
				_scalingCoordinates[1] ? _targetScale.y : _startScale.y,
				_scalingCoordinates[2] ? _targetScale.z : _startScale.z);
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