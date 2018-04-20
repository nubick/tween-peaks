using TweenPeaks.Tweens;
using UnityEngine;

namespace Assets.Scripts.Demo.TweenActions
{
    public class Jump2DTweenAction : TweenAction
    {
        public override void Run(GameObject target, TweenActionSettings s)
        {
            Jump2DTween.Run(target, GetRandomScreenPoint(), s.Duration).SetJumpYOffset(100).SetDelay(s.Delay);
        }
    }
}
