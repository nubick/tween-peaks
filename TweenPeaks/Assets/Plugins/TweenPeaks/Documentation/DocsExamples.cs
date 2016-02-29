using Assets.Plugins.TweenPeaks.Tweens;
using UnityEngine;

namespace Assets.Plugins.TweenPeaks.Documentation
{
    public class DocsExamples : MonoBehaviour
    {
        public GameObject Star;

        public GameObject Star1;
        public GameObject Star2;
        public GameObject Star3;

        public void FadeOutStar()
        {
            FadeOutTween.Run(Star, 0.5f);
        }

        public void FadeInStar()
        {
            FadeInTween.Run(Star, 0.5f);
        }

        public void FadeOutAndFadeInStar()//todo: don't work, fix!
        {
            FadeOutTween.Run(Star, 0.5f);
            FadeInTween.Run(Star, 0.5f).SetDelay(0.5f);
        }

        public void FadeOutAndFadeInStar2()
        {
            FadeOutTween.Run(Star, 0.5f)
                .OnFinish(() =>
                {
                    FadeInTween.Run(Star, 0.5f);
                });
        }

        public void FadeOutAndFadeInStar3()
        {
            TweenSequence.Run2(
                () => FadeOutTween.Run(Star, 0.5f),
                () => FadeInTween.Run(Star, 0.5f));
        }

        public void ThreeStarsFadeOut()
        {
            FadeOutTween.Run(Star1, 0.25f);
            FadeOutTween.Run(Star2, 0.25f).SetDelay(0.15f);
            FadeOutTween.Run(Star3, 0.25f).SetDelay(0.30f);
        }

        public void ThreeStarsFadeIn()
        {
            FadeInTween.Run(Star1, 0.25f);
            FadeInTween.Run(Star2, 0.25f).SetDelay(0.15f);
            FadeInTween.Run(Star3, 0.25f).SetDelay(0.30f);
        }

        public void OnGUI()
        {
            GUILayout.BeginVertical();

            if (GUILayout.Button("FadeOut star"))
            {
                FadeOutStar();
            }

            if (GUILayout.Button("FadeIn star"))
            {
                FadeInStar();
            }

            if (GUILayout.Button("FadeOut and FadeIn star"))
            {
                FadeOutAndFadeInStar();
            }

            if (GUILayout.Button("FadeOut and FadeIn star 2"))
            {
                FadeOutAndFadeInStar2();
            }

            if (GUILayout.Button("FadeOut and FadeIn star 3"))
            {
                FadeOutAndFadeInStar3();
            }

            if (GUILayout.Button("Three stars fade out"))
            {
                ThreeStarsFadeOut();
            }

            if (GUILayout.Button("Three stars fade in"))
            {
                ThreeStarsFadeIn();
            }

            GUILayout.EndVertical();
        }
    }
}
