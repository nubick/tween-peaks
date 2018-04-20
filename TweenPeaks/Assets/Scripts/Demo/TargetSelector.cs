using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Demo.TweenActions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Demo
{
    public class TargetSelector : MonoBehaviour
    {
        public EventSystem EventSystem;
        public TweenActionSelector TweenActionSelector;
        public SettingsSelector SettingsSelector;
        public int IgnoreAsTargetLayerId;

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
                        if (result.gameObject.layer == IgnoreAsTargetLayerId)
                            continue;

                        RunTween(result.gameObject);            
                        break;
                    }
                }
            }
        }

        private void RunTween(GameObject target)
        {
            if (TweenActionSelector.SelectedTweenAction != null)
            {
                TweenActionSelector.SelectedTweenAction.Run(target, SettingsSelector.GetSettings());
            }
        }
    }
}
