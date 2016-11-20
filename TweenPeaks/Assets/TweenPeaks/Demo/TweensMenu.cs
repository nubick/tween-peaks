using UnityEngine;

namespace Assets.Plugins.TweenPeaks.Demo
{
    public class TweensMenu : ViewBase
    {
        public FadeTweensView FadeTweensView;

        public void ShowFadeTweens()
        {
            SwitchTo(FadeTweensView);    
        }

    }
}
