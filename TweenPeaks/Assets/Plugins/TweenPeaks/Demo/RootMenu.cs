

namespace Assets.Plugins.TweenPeaks.Demo
{
    public class RootMenu : ViewBase
    {
        public TweensMenu TweensMenu;
        public LoopsMenu LoopsMenu;

        public void GoToTweens()
        {
            SwitchTo(TweensMenu);
        }

        public void GoToLoops()
        {
            SwitchTo(LoopsMenu);
        }
    }
}
