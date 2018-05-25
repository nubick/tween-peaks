using System.Collections;
using TweenPeaks.Tweens;
using UnityEngine;

namespace Assets.Scripts.Demo.TweenActions
{
	public class KickTweenAction : TweenAction
	{
		public override void Run(GameObject target, TweenActionSettings settings)
		{
			CoroutinesHoster.StartCoroutine(KickSequenceCoroutine(target, settings));

			//TweenSequence.Run5(
				//() => KickTween.RunLeft(target, 100f),
				//() => KickTween.RunRight(target, 100f),
				//() => KickTween.RunUp(target, 100f),
				//() => KickTween.RunDown(target, 100f),
				//() => KickTween.RunDirection(target, 100f, new Vector2(4f, 3f)));
		}

		private IEnumerator KickSequenceCoroutine(GameObject target, TweenActionSettings settings)
		{
			yield return KickTween.RunLeft(target, 100f).WaitForFinish();
			yield return KickTween.RunRight(target, 100f).WaitForFinish();

			TweenBase tween = KickTween.RunUp(target, 100f);
			while (tween.IsRunning())
				yield return null;

			tween = KickTween.RunDown(target, 100f);
			yield return new WaitForSeconds(0.01f);
			Object.DestroyImmediate(tween);

			if (tween.IsFinished())
				yield return KickTween.RunDown(target, 100f).WaitForFinish();

			KickTween.RunDirection(target, 100f, new Vector2(2f, 1.5f));
		}
	}
}
