using TweenPeaks.Tweens;
using UnityEngine;

namespace Assets.Scripts.Demo.TweenActions
{
    public class MoveToTweenAction : TweenAction
    {
        public override void Run(GameObject target, TweenActionSettings s)
        {
            int example = Random.Range(0, 2);
            if (example == 0)
            {
                MoveToTween.Run(target, GetRandomScreenPoint(), s.Duration).SetLocal(true).SetDelay(s.Delay).SetEase(s.Ease);
            }
            else if (example == 1)
            {
                MoveToTween.RunX(target, GetRandomScreenPoint().x, s.Duration).SetLocal(true).SetDelay(s.Delay).SetEase(s.Ease);
            }
        }
    }
}
