using Assets.Plugins.TweenPeaks.Tweens;
using UnityEngine;

namespace Assets.Plugins.TweenPeaks.Loops
{
    public class MoveLoop : Loop
    {
        private Vector3 _startPosition;

        public Vector3 Offset;
        public float Duration = 1f;
        public Ease Ease;

        public void Awake()
        {
            _startPosition = transform.position;
        }

        public void OnEnable()
        {
            RunPartOneMoveTween();
        }

        public void OnDisable()
        {
            MoveToTween moveToTween = GetComponent<MoveToTween>();
            if (moveToTween != null)
                Destroy(moveToTween);
        }

        private void RunPartOneMoveTween()
        {
            transform.position = _startPosition;
            MoveToTween.Run(gameObject, _startPosition + Offset, Duration).SetEase(Ease).OnFinish(RunPartTwoMoveTween);
        }

        private void RunPartTwoMoveTween()
        {
            transform.position = _startPosition + Offset;
            MoveToTween.Run(gameObject, _startPosition, Duration).SetEase(Ease).OnFinish(RunPartOneMoveTween);
        }
    }
}
