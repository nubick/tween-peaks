using TweenPeaks.Tweens;
using UnityEngine;

namespace Assets.Scripts.Demo.TweenActions
{
	public class ScaleTweenAction : TweenAction
	{
		public override void Run(GameObject target, TweenActionSettings s)
		{
			int variant = Random.Range(0, 3);

			if (variant == 0)
			{
				TweenSequence.Run2(
					() => ScaleTween.Run(target, Vector3.zero, s.Duration).SetEase(s.Ease).SetDelay(s.Delay),
					() => ScaleTween.Run(target, Vector3.one, s.Duration).SetEase(s.Ease));
			}
			else if (variant == 1)
			{
				TweenSequence.Run2(
					() => ScaleTween.RunX(target, 0f, s.Duration).SetEase(s.Ease).SetDelay(s.Delay),
					() => ScaleTween.RunX(target, 1f, s.Duration).SetEase(s.Ease));
			}
			else if (variant == 2)
			{
				TweenSequence.Run2(
					() => ScaleTween.RunY(target, 0f, s.Duration).SetEase(s.Ease).SetDelay(s.Delay),
					() => ScaleTween.RunY(target, 1f, s.Duration).SetEase(s.Ease));
			}
		}
	}
}
