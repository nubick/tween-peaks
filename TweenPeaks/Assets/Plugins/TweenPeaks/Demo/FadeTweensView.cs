using System.Collections.Generic;
using System.Linq;
using Assets.Plugins.TweenPeaks.Tweens;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Plugins.TweenPeaks.Demo
{
    public class FadeTweensView : ViewBase
    {
        public TweensMenu TweensMenu;
        public EventSystem EventSystem;
        public float MinDuration;
        public float MaxDuration;

        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.IsPointerOverGameObject())
                {
                    PointerEventData pd = new PointerEventData(EventSystem) { position = Input.mousePosition };
                    List<RaycastResult> results = new List<RaycastResult>();
                    EventSystem.RaycastAll(pd, results);
                    foreach (RaycastResult result in results.OrderByDescending(_ => _.depth))
                    {
                        RunTween(result.gameObject);//run just for first nearest
                        break;
                    }
                }
            }
        }

        private void RunTween(GameObject clickedObject)
        {
            FadeOutTween.Run(clickedObject, GetRandomDuration())
                .OnFinish(() =>
                {
                    if (Random.Range(0, 2) == 0)
                        clickedObject.SetActive(true);
                    else
                        FadeInTween.Run(clickedObject, GetRandomDuration());
                });
        }

        private float GetRandomDuration()
        {
            return Random.Range(MinDuration, MaxDuration);
        }

        public void GoBack()
        {
            SwitchTo(TweensMenu);
        }

    }
}
