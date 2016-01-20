using UnityEngine;

namespace Assets.Plugins.TweenPeaks.Demo
{
    public class ViewBase : MonoBehaviour
    {
        public GameObject Content;
        public bool IsVisibleOnLaunch;

        public void Awake()
        {
            Content.SetActive(IsVisibleOnLaunch);
        }

        public void Show()
        {
            Content.SetActive(true);
        }

        public void Hide()
        {
            Content.SetActive(false);
        }

        public void SwitchTo(ViewBase view)
        {
            Hide();
            view.Show();
        }
    }
}
