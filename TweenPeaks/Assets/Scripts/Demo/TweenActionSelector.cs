using Assets.Scripts.Demo.TweenActions;
using UnityEngine;

namespace Assets.Scripts.Demo
{
	public class TweenActionSelector : MonoBehaviour
	{
		public TweenAction SelectedTweenAction { get; set; }

		public void SelectColorFlashTween()
		{
			SelectedTweenAction = new ColorFlashTweenAction();
		}

		public void SelectScaleTween()
		{
			SelectedTweenAction = new ScaleTweenAction();
		}

		public void SelectNumberRunTween()
		{
			SelectedTweenAction = new NumberRunTweenAction();
		}

		public void SelectShakeTween()
		{
			SelectedTweenAction = new ShakeTweenAction();
		}

		public void SelectShakeAngleTween()
		{
			SelectedTweenAction = new ShakeAngleTweenAction();
		}

		public void SelectKickTween()
		{
			SelectedTweenAction = new KickTweenAction();
		}

		public void SelectValueTween()
		{
			SelectedTweenAction = new ValueTweenAction();
		}

		public void SelectJump2DTween()
		{
			SelectedTweenAction = new Jump2DTweenAction();
		}

		public void SelectFadeInOutTweens()
		{
			SelectedTweenAction = new FadeTweensAction();
		}

		public void SelectMoveToTween()
		{
			SelectedTweenAction = new MoveToTweenAction();
		}
	}
}
