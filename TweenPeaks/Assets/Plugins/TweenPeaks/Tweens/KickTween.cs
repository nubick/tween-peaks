using UnityEngine;

namespace TweenPeaks.Tweens
{
	public class KickTween
	{
		private const float KickDuration = 0.25f;

		public static ShakeTween RunDirection(GameObject gameObject, float kickDistance, Vector2 direction)
		{
			return ShakeTween.Run(gameObject, kickDistance, direction, KickDuration).SetPhasesCount(2);
		}

		public static ShakeTween RunLeft(GameObject gameObject, float kickDistance)
		{
			return RunDirection(gameObject, kickDistance, new Vector2(-1f, 0f));
		}

		public static ShakeTween RunRight(GameObject gameObject, float kickDistance)
		{
			return RunDirection(gameObject, kickDistance, new Vector2(1f, 0f));
		}

		public static ShakeTween RunUp(GameObject gameObject, float kickDistance)
		{
			return RunDirection(gameObject, kickDistance, new Vector2(0f, 1f));
		}

		public static ShakeTween RunDown(GameObject gameObject, float kickDistance)
		{
			return RunDirection(gameObject, kickDistance, new Vector2(0f, -1f));
		}
	}
}