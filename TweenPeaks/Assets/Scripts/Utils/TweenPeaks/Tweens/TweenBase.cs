using System;
using UnityEngine;

namespace Assets.Scripts.Utils.TweenPeaks.Tweens
{
    public abstract class TweenBase : MonoBehaviour
    {
        private bool _isStarted;
        protected float _startTime;
        protected float _duration;
        protected Func<float, float, float, float> EaseFunc;

        public Action FinishAction { get; private set; }


        public static T Create<T>(GameObject item, float duration) where T : TweenBase
        {
            T tween = item.gameObject.AddComponent<T>();
            tween.EaseFunc = Mathf.Lerp;
            tween._duration = duration;
            tween._startTime = Time.time;
            return tween;
        }

        public TweenBase SetEase(Func<float, float, float, float> easeFunc)
        {
            EaseFunc = easeFunc;
            return this;
        }

        public TweenBase SetEase(Ease ease)
        {
            EaseFunc = EaseFunctions.Get(ease);
            return this;
        }

        public TweenBase SetDelay(float delay)
        {
            _startTime = Time.time + delay;
            return this;
        }

        public TweenBase Single()
        {
            foreach (TweenBase tween in gameObject.GetComponents<TweenBase>())
                if (tween != this)
                    tween.Finish();
            return this;
        }

        public void Update()
        {
            if (_isStarted)
            {
                float time = (Time.time - _startTime) / _duration;
                if (time > 1f)
                {
                    Finish();
                }
                else
                {
                    UpdateValue(time);
                }
            }
            else if (Time.time >= _startTime)
            {
                _isStarted = true;
                OnStart();
            }
        }

        protected virtual void OnStart() { }

        protected abstract void UpdateValue(float time);

        public void Finish()
        {
            UpdateValue(1f);
            Destroy(this);
            OnFinish();
        }

        protected virtual void OnFinish()
        {
            if (FinishAction != null)
                FinishAction();
        }

        public TweenBase OnFinish(Action finishAction)
        {
            FinishAction = finishAction;
            return this;
        }

        /// <summary>
        /// Finishs all tweens of any types on game object. Call Finish and Destroy tweens.
        /// </summary>
        public static void FinishAll(GameObject item)
        {
            foreach (TweenBase tweenBase in item.GetComponents<TweenBase>())
                tweenBase.Finish();
        }

        /// <summary>
        /// Finish all tweens of type T on game object. Call Finish and Destroy tweens.
        /// </summary>
        public static void FinishAll<T>(GameObject item)
            where T : TweenBase
        {
            foreach (T tween in item.GetComponents<T>())
                tween.Finish();
        }

        /// <summary>
        /// Destroy all tweens of any types from game object. Don't call Finish.
        /// </summary>
        /// <param name="item">Item.</param>
        public static void BreakAll(GameObject item)
        {
            foreach (TweenBase tweenBase in item.GetComponents<TweenBase>())
                Destroy(tweenBase);
        }

        /// <summary>
        /// Destroy all tweens of type T from game object. Don't call Finish.
        /// </summary>
        public static void BreakAll<T>(GameObject item)
            where T : TweenBase
        {
            foreach (T tween in item.GetComponents<T>())
                Destroy(tween);
        }

    }
}
