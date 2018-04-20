using TweenPeaks.Tweens;
using UnityEngine;

namespace TweenPeaks.Loops
{
    public class ScaleLoop : Loop
    {
        public Vector3 ScaleOne = new Vector3(1f, 1f, 1f);
        public Ease EaseOne;
        public float DurationOne = 0.5f;

        public Vector3 ScaleTwo = new Vector3(0.5f, 0.5f, 0.5f);
        public Ease EaseTwo;
        public float DurationTwo = 0.5f;

        public void OnEnable()
        {
            RunPartOneScaleTween();
        }

        public void OnDisable()
        {
            ScaleTween scaleTween = GetComponent<ScaleTween>();
            if (scaleTween != null)
                Destroy(scaleTween);
        }

        private void RunPartOneScaleTween()
        {
            transform.localScale = ScaleOne;
            ScaleTween.Run(gameObject, ScaleTwo, DurationOne).SetEase(EaseOne).OnFinish(RunPartTwoScaleTween);
        }

        private void RunPartTwoScaleTween()
        {
            transform.localScale = ScaleTwo;
            ScaleTween.Run(gameObject, ScaleOne, DurationTwo).SetEase(EaseTwo).OnFinish(RunPartOneScaleTween);
        }
    }
}