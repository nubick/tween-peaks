using TweenPeaks.Tweens;
using UnityEngine;

namespace Assets.Scripts.Demo.TweenActions
{
    public class CameraTweenAction : TweenAction
    {
        public override void Run(GameObject target, TweenActionSettings s)
        {
            float startSize = Camera.main.orthographicSize;
            TweenSequence.Run2(
                () => CameraTween.ChangeSize(Camera.main, 200, s.Duration).SetEase(s.Ease),
                () => CameraTween.ChangeSize(Camera.main, startSize, s.Duration).SetEase(s.Ease).SetDelay(1f));

        }
    }
}
