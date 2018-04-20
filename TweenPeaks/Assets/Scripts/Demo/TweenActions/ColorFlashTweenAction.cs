using TweenPeaks.Tweens;
using UnityEngine;

namespace Assets.Scripts.Demo.TweenActions
{
    public class ColorFlashTweenAction : TweenAction
    {
        public override void Run(GameObject target, TweenActionSettings settings)
        {
            ColorFlashTween.Run(target, settings.Color, settings.Duration)
                .SetDelay(settings.Delay)
                .SetEase(settings.Ease)
                .Single();
        }
    }
}
