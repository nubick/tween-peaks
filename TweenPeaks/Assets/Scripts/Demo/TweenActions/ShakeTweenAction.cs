using Assets.Scripts.Utils.TweenPeaks.Tweens;
using UnityEngine;

namespace Assets.Scripts.Demo.TweenActions
{
    public class ShakeTweenAction : TweenAction
    {
        public override void Run(GameObject target, TweenActionSettings s)
        {
            TweenSequence.Run3(
                () => ShakeTween.Run(target, 25, s.Duration),
                () => ShakeTween.RunVertical(target, 25, s.Duration),
                () => ShakeTween.Run(target, 25, s.Duration).SetDirection(new Vector2(3f, 1f)));
        }
    }
}
