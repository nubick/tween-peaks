using UnityEngine;

namespace Assets.Plugins.TweenPeaks.Demo
{
    public class RootMenu : MonoBehaviour
    {
        public GameObject Tweens;
        public GameObject Loops;

        public void GoToTweens()
        {
            Tweens.SetActive(true);
        }

        public void GoToLoops()
        {
            Loops.SetActive(true);
        }
    }
}
