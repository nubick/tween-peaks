using TweenPeaks.Tweens;
using UnityEngine;

namespace Assets.Scripts.Demo.TweenActions
{
	public class ShakeAngleTweenAction : TweenAction
	{
		public override void Run(GameObject target, TweenActionSettings settings)
		{
			int variant = Random.Range(0, 3);

			if (variant == 0)
				ShakeAngleTween.Run(target, 10f, settings.Duration).Single();
			else if (variant == 1)
				ShakeAngleTween.Run(target, 20f, 0.25f).SetPhasesCount(2).Single();
			else if (variant == 2)
				ShakeAngleTween.Run(Camera.main.gameObject, 10f, 0.25f).SetPhasesCount(2).Single();
		}
	}
}
