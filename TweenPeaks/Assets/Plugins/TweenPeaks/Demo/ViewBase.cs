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
            OnShow();
        }

        protected virtual void OnShow() { }

        public void Hide()
        {
            Content.SetActive(false);
            OnHide();
        }

        protected virtual void OnHide() { }

        public void SwitchTo(ViewBase view)
        {
            Hide();
            view.Show();
        }

        public bool IsActive { get { return Content.activeSelf; } }
    }
}
