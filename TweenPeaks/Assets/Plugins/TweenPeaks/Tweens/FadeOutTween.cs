using UnityEngine;

namespace Assets.Plugins.TweenPeaks.Tweens
{
	public class FadeOutTween : FadeTweenBase
	{
		public static FadeOutTween Run(GameObject item, float duration)
		{
			return Create<FadeOutTween>(item, duration);
		}

		protected override void OnStart()
		{
			Initialize();
			UpdateValue(0);
		}

	    protected  override float GetAlpha(float startAlpha, float time)
	    {
	        return EaseFunc(startAlpha, 0f, time);
	    }

        protected override void OnFinish()
		{
			gameObject.SetActive(false);
            UpdateValue(0f);
			base.OnFinish();
		}
	}
}
