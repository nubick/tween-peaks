using Assets.Scripts.Demo.TweenActions;
using Assets.Scripts.Utils.TweenPeaks;
using UnityEngine;

namespace Assets.Scripts.Demo
{
    public class SettingsSelector : MonoBehaviour
    {
        public float Duration;
        public float Delay;
        public Ease Ease;
        public Color Color;

        public TweenActionSettings GetSettings()
        {
            return new TweenActionSettings
            {
                Duration = Duration,
                Delay = Delay,
                Ease = Ease,
                Color = Color
            };
        }
    }
}
