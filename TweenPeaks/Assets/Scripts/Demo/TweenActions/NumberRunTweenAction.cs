using Assets.Scripts.Utils.TweenPeaks.Tweens;
using UnityEngine;

namespace Assets.Scripts.Demo.TweenActions
{
    public class NumberRunTweenAction : TweenAction
    {
        public override void Run(GameObject target, TweenActionSettings s)
        {
            NumberRunTween.Run(target, 1, 99, s.Duration).SetEase(s.Ease).SetDelay(s.Delay);
        }
    }
}
