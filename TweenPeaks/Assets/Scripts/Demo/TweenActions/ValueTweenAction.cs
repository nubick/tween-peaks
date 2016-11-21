using Assets.Scripts.Utils.TweenPeaks.Tweens;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Demo.TweenActions
{
    public class ValueTweenAction : TweenAction
    {
        public override void Run(GameObject target, TweenActionSettings s)
        {
            Text textComponent = target.GetComponent<Text>();
            if (textComponent == null)
            {
                Debug.Log("Test error! Can't test ValueTween. Select text component before.");
            }
            else
            {
                bool isIntegerValue = Random.Range(0, 2) == 0;
                if (isIntegerValue)
                {
                    ValueTween.Run(target, 10, 100, s.Duration,
                        iValue =>
                        {
                            textComponent.text = iValue.ToString();
                        }).SetEase(s.Ease).SetDelay(s.Delay);
                }
                else
                {
                    ValueTween.Run(target, 100f, 10f, s.Duration,
                        fValue =>
                        {
                            textComponent.text = fValue.ToString("F");
                        }).SetEase(s.Ease).SetDelay(s.Delay);
                }
            }
        }
    }
}
