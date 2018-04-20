using TweenPeaks.Tweens;
using UnityEngine;

namespace TweenPeaks.Loops
{
    public class MoveLoop : Loop
    {
        private Vector2 _startLocalPosition;

        [HideInInspector] public Vector2 Offset;
        [HideInInspector] public float Length;
        public float Duration = 1f;
        public Ease Ease;
        public bool RandomStart;

        public Vector2 StartPoint { get { return _startLocalPosition + Offset; } }
        public Vector2 FinishPoint { get { return StartPoint - Offset.normalized * Length; } }

        public void Awake()
        {
            _startLocalPosition = transform.localPosition;
        }

        public void OnEnable()
        {
            if (RandomStart)
            {
                transform.localPosition = GetRandomStartPosition();
                bool isStartFromPartOneMove = Random.Range(0, 2) == 0;
                float partLength = Vector2.Distance(transform.localPosition, isStartFromPartOneMove ? StartPoint : FinishPoint);
                float partDuration = Duration * partLength / Length;
                if (isStartFromPartOneMove)
                    RunPartOneMoveTween(partDuration);
                else
                    RunPartTwoMoveTween(partDuration);
            }
            else
            {
                RunPartOneMoveTween(Duration);
            }
        }

        public void OnDisable()
        {
            TweenBase.BreakAll<MoveToTween>(gameObject);
        }

        private void RunPartOneMoveTween(float duration)
        {
            MoveToTween.Run(gameObject, StartPoint, duration).SetLocal(true).SetEase(Ease).OnFinish(() => RunPartTwoMoveTween(Duration));
        }

        private void RunPartTwoMoveTween(float duration)
        {
            MoveToTween.Run(gameObject, FinishPoint, duration).SetLocal(true).SetEase(Ease).OnFinish(() => RunPartOneMoveTween(Duration));
        }

        private Vector3 GetRandomStartPosition()
        {
            float t = Random.Range(0f, 1f);
            return new Vector2(Mathf.Lerp(StartPoint.x, FinishPoint.x, t), Mathf.Lerp(StartPoint.y, FinishPoint.y, t));
        }
    }
}