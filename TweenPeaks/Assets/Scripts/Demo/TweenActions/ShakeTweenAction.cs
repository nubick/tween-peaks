using TweenPeaks.Tweens;
using UnityEngine;

namespace Assets.Scripts.Demo.TweenActions
{
    public class ShakeTweenAction : TweenAction
    {
        public override void Run(GameObject target, TweenActionSettings s)
        {
            if (Random.Range(0, 2) == 0)
            {
                Debug.Log("ShakeTween.Run.");
                TweenSequence.Run3(
                    () => ShakeTween.Run(target, 25, s.Duration),
					() => ShakeTween.RunUp(target, 25, s.Duration),
					() => ShakeTween.Run(target, 25, new Vector2(3f, 1f), s.Duration));
            }
            else
            {
                Debug.Log("ShakeTween.Run.Local.");
				TweenSequence.Run3(
					() => ShakeTween.Run(target, 25, s.Duration).SetLocal(),
					() => ShakeTween.RunUp(target, 25, s.Duration).SetLocal(),
					() => ShakeTween.Run(target, 25, new Vector2(3f, 1f), s.Duration).SetLocal());
            }
        }
    }
}
