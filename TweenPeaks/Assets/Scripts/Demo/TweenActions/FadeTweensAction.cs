using TweenPeaks.Tweens;
using UnityEngine;

namespace Assets.Scripts.Demo.TweenActions
{
    public class FadeTweensAction : TweenAction
    {
        public override void Run(GameObject target, TweenActionSettings s)
        {
            TweenSequence.Run2(
                () => FadeOutTween.Run(target, s.Duration).SetEase(s.Ease),
                () => FadeInTween.Run(target, s.Duration).SetEase(s.Ease));
        }
    }
}
