using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

namespace Assets.Plugins.TweenPeaks.Demo
{
    public class FadeTweensView 
    {
        //private float _lastClickTime;
        //private Coroutine _automaticRunCoroutine;

        //public TweensMenu TweensMenu;
        //public EventSystem EventSystem;
        //public float MinDuration;
        //public float MaxDuration;
        //public GameObject[] TweenableItems;

        //protected override void OnShow()
        //{
        //    _lastClickTime = Time.time;
        //}

        //protected override void OnHide()
        //{
        //    StopAutomaticRunCoroutine();
        //}

        //private void StartAutomaticRunCoroutine()
        //{
        //    if (_automaticRunCoroutine == null)
        //    {
        //        _automaticRunCoroutine = StartCoroutine(AutomaticRunCoroutine());
        //    }
        //}

        //private void StopAutomaticRunCoroutine()
        //{
        //    if (_automaticRunCoroutine != null)
        //    {
        //        StopCoroutine(_automaticRunCoroutine);
        //        _automaticRunCoroutine = null;
        //    }
        //}

        //private IEnumerator AutomaticRunCoroutine()
        //{
        //    for (;;)
        //    {
        //        GameObject tweenableItem = TweenableItems[Random.Range(0, TweenableItems.Length)];
        //        RunTween(tweenableItem);
        //        yield return new WaitForSeconds(0.5f);
        //    }
        //} 

        //public void Update()
        //{
        //    if (!IsActive)
        //        return;

        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        _lastClickTime = Time.time;
        //        StopAutomaticRunCoroutine();

        //        if (EventSystem.IsPointerOverGameObject())
        //        {
        //            PointerEventData pd = new PointerEventData(EventSystem) { position = Input.mousePosition };
        //            List<RaycastResult> results = new List<RaycastResult>();
        //            EventSystem.RaycastAll(pd, results);
        //            foreach (RaycastResult result in results.OrderByDescending(_ => _.depth))
        //            {
        //                RunTween(result.gameObject);//run just for first nearest
        //                break;
        //            }
        //        }
        //    }

        //    if (Time.time - _lastClickTime > 10f)
        //    {
        //        StartAutomaticRunCoroutine();
        //    }
        //}

      

    }
}
