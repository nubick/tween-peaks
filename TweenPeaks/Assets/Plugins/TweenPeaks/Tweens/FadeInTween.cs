using UnityEngine;

namespace TweenPeaks.Tweens
{
    public class FadeInTween : FadeTweenBase
    {
        public static FadeInTween Run(GameObject item, float duration)
        {
            FadeInTween fadeInTween = Create<FadeInTween>(item, duration);
            fadeInTween.Initialize();
            fadeInTween.UpdateValue(0);
            item.SetActive(true);
            return fadeInTween;
        }

        protected override float GetAlpha(float startAlpha, float time)
        {
            return EaseFunc(0f, startAlpha, time);
        }
    }
}
