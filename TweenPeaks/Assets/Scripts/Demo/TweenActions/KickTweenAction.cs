using TweenPeaks.Tweens;
using UnityEngine;

namespace Assets.Scripts.Demo.TweenActions
{
    public class KickTweenAction : TweenAction
    {
        public override void Run(GameObject target, TweenActionSettings settings)
        {
            TweenSequence.Run5(
                () => KickTween.RunLeft(target, 100f),
                () => KickTween.RunRight(target, 100f),
                () => KickTween.RunUp(target, 100f),
                () => KickTween.RunDown(target, 100f),
                () => KickTween.RunDirection(target, 100f, new Vector2(4f, 3f)));
        }
    }
}
