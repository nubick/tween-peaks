using Assets.Scripts.Utils.TweenPeaks.Tweens;
using UnityEngine;

namespace Assets.Scripts.Demo.TweenActions
{
    public class ScaleTweenAction : TweenAction
    {
        public override void Run(GameObject target, TweenActionSettings s)
        {
            TweenSequence.Run2(
                () => ScaleTween.Run(target, Vector3.zero, s.Duration).SetEase(s.Ease).SetDelay(s.Delay),
                () => ScaleTween.Run(target, Vector3.one, s.Duration).SetEase(s.Ease));
        }
    }
}
